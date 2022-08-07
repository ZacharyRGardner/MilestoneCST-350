using Microsoft.AspNetCore.Http;
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
                HttpContext.Session.SetString("username", login.username);

                return View("LoginSuccess", login);
                
            }
            else 
            {

                HttpContext.Session.Remove("username");
                return View("LoginFailure", login);
            };
        }
    }
}
