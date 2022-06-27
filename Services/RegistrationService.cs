using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Services
{
    public class RegistrationService
    {
        RegistrationDAO registrationDAO = new RegistrationDAO();

        public bool RegisterUser(UserModel user)
        {
            return registrationDAO.RegisterUser(user);
        }
    }
}
