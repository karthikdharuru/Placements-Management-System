using DataAccess_Layer.Dataaccess;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Bussiness_Layer.Logic
{
    public class HomeLogic
    {
        //check the logged in user is student or admin
        public string RoleForUser()
        {
            
                if (Roles.IsUserInRole("Student"))
                {
                    return "Student";
                }
                else if(Roles.IsUserInRole("Admin"))
                {
                    return "Admin";
                }
            
            else
            {
                return "noUser";
            }
        }
        //check login credentials
        public string IsLoginValid(Login login)
        {
           LoginDb session = new LoginDb();
            return session.IsLoginValid(login);

        }
    }
}
