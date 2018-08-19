using Constans.Claims;
using DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public static class DatabaseInitializer
    {

        private static IDictionary<string, IList<string>> permissions = new Dictionary<string, IList<string>>()
        {
            { "Constructor",new List<string>(new string[] { Permissions.Engines.Manage, })},
            { "ConstructorReader",new List<string>(new string[] { Permissions.Engines.Get })},
            { "Administrator", new List<string>(new string[] { Permissions.Users.Add, Permissions.Users.Delete, Permissions.Users.Edit, Permissions.Users.EditRole, Permissions.Users.Get })}
        };

        public static async Task InitializeData(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<AppContext>();
                db.Database.Migrate();
                await SeedData(db);
            }
        }


        private static async Task SeedData(AppContext context)
        {
            if (context.Engines.Any())
                return;
            var engine = new Engine { Manufacturer = "Peugeot", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now};
            context.Add(engine);
            await context.SaveChangesAsync();
        }

        public static async Task SeedIdentityItems(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach(KeyValuePair<string, IList<string>> item in permissions)
            {

                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(item.Key));
                if(result.Succeeded)
                {
                    IdentityRole role = roleManager.FindByNameAsync(item.Key).Result;
                    foreach (String claim in item.Value)
                    {
                        await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, claim));
                    }
                }
            }            
        }
    }
}
