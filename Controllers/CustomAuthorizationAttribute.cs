using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MilestoneCST_350.Controllers
{
    internal class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string username = context.HttpContext.Session.GetString("username");

            if (username == null)
            {
                context.Result = new RedirectResult("/login");
            }
            
        }
    }
}