using DataAccess_Layer.Dataaccess;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Security;

namespace Bussiness_Layer.Logic
{
    public class AdminLogic
    {
        
        //check whether admin is already logged in or not
        public bool IsAlreadyLoggedIn()
        {
            if (Roles.IsUserInRole("Admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //delete the student from temp_database and register in student_base
        public bool Isaccepted(string StudentEmail)
        {
            TempStudentDb temp = new TempStudentDb();

            Student student = temp.RetrieveStudent(StudentEmail);
            AdminDb admin = new AdminDb();
            
            bool Issuccess=false;
            //for accepting update request
            if (Roles.IsUserInRole(StudentEmail, "Student"))
            {
                Issuccess = admin.UpdateStudent(student);
            }
            //for accepting new registrations
            else
            {

                Issuccess = admin.AddStudent(student);

            }
            bool Isdeleted = false;
            if (Issuccess == true)
            {
                //delete from temp database
                 Isdeleted = temp.DeleteStudent(StudentEmail);
            }

            return Isdeleted && Issuccess;
        }

        //check whether student with student id exists or not
        public bool CheckStudentId(int StudentId)
        {
            AdminDb admin = new AdminDb();

            if (admin.IsStudentExists(StudentId))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        //details are updated in db or not
        public bool Isupdated(Student student)
        {
            AdminDb admin = new AdminDb();
            return admin.UpdateStudent(student);
        }

    }
}
