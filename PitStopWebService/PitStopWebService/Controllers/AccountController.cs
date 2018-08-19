using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Constans.Claims;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using ViewModel;
using ViewModel.Account;

namespace PitStopWebService.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager = null;

        private readonly RoleManager<IdentityRole> roleManager = null;

        private readonly SignInManager<User> signInManager = null;

        private readonly IAccountService accountService = null;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager, 
            RoleManager<IdentityRole> roleManager, IAccountService accountService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.accountService = accountService;
        }

        [HttpPost("claim")]
        public async Task<IActionResult> Claim()
        {
            string id = "853634c8-721e-4256-b9f2-1783cadb37aa";
            User user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "ConstructorReader");
            IList<string> roles = await userManager.GetRolesAsync(user);
            IdentityRole role = await roleManager.FindByNameAsync(roles[0]);
            IList<Claim> claims = await roleManager.GetClaimsAsync(role);
            await userManager.AddClaimAsync(user, claims[0]);
            return NoContent();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = registerViewModel.MapTo();
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.EmploymentCommenced, DateTime.Now.ToString(), ClaimValueTypes.DateTime));
                    return new JsonResult(new Dictionary<string, object>
                      {
                        { "auth_token", this.accountService.GenerateEncodedToken(user) }
                      });
                }
                return this.accountService.Errors(result);

            }
            return this.accountService.Error("Unexpected error");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(loginViewModel.Email);
                    return new JsonResult(new Dictionary<string, object>
                      {
                        { "auth_token", this.accountService.GenerateEncodedToken(user) }
                      });
                }
                return new JsonResult("Invalid credentials") { StatusCode = 401 };
            }
            return this.accountService.Error("Unexpected error");
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return new JsonResult("User logged out");
        }

    }
}