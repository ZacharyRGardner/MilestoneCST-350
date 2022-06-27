using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(LoginModel login)
        {
            return securityDAO.FindUserByNameAndPassword(login);
        }
    }
}
