using DataAccess_Layer.Dataaccess;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer.Logic
{
    public class AdminDelete
    {
        //check details are deleted or not in temp_student
        public bool IsRejected(string Email)
        {
            // delete details permanently
             TempStudentDb temp = new TempStudentDb();

            return temp.DeleteStudent(Email);
            
        }

        //check whether details are deleted or not in student_base
        public bool IsDeleted(Student student)
        {
            AdminDb admin = new AdminDb();
            return admin.DeleteStudent(student);

        }
    }
}
