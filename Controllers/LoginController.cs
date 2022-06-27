using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350.Models;
using MilestoneCST_350.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(LoginModel login)
        {
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(login))
            {
                return View("LoginSuccess", login);
            }
            else 
            {
                return View("LoginFailure", login);
            };
        }
    }
}
