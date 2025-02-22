using DataAccess_Layer.Dataaccess;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer.Logic
{
    public class StudentRetrieve
    {
        //retrieve student details from student_base
        public Student GetStudentDetails(string StudentEmail)
        {

            StudentDb getStudent = new StudentDb();

            return getStudent.RetrieveStudent(StudentEmail);
        }
    }
}
