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
    public class StudentLogic
    {

        

        //check student is already logged in
        public bool IsAlreadyLoggedIn()
        {
            if (Roles.IsUserInRole("Student"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //student is already register in database
        public bool IsAlreadyRegistered(Student student)
        {
            if (Roles.IsUserInRole(student.Email, "Student"))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        //check student data is inserted or not
        public bool IsRegistered(Student student)
        {
            TempStudentDb tempstudent = new TempStudentDb();
            return tempstudent.RegisterStudent(student);
        }
    }
}
