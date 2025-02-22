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
    public class Admininsert
    {
        //if student not already regsitered then register the student
        public bool IsAdded(Student student)
        {
            if (Roles.IsUserInRole(student.Email, "Student"))
            {
                return false;
            }
            else
            {

                AdminDb admin = new AdminDb();
                bool Issucess = admin.AddStudent(student);
                return Issucess;

            }
        }
    }
}
