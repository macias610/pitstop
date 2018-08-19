using DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Classes;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        int GetValidPeriod();
        JsonResult Error(string message);
        JsonResult Errors(IdentityResult result);
        Task<string> GenerateEncodedToken(User user);
    }
}
