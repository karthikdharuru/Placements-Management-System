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
    public class AdminRetrieve
    {
        //get all student who are not registered
        public List<Student> getStudents()
        {
                TempStudentDb temp = new TempStudentDb();
                List<Student> students = temp.YettORegister();
                return students;
           
        }
        //retrieve by student email from temp database
        public Student getStudentFromTemp(string Email)
        {
            TempStudentDb temp = new TempStudentDb();
            Student student = temp.RetrieveStudent(Email);
            return student;

        }
        //retrieve by student email from student_base
        public Student getStudent(string StudentEmail)
        {
            StudentDb temp = new StudentDb();
            Student student = temp.RetrieveStudent(StudentEmail);
            return student;

        }
        //retrieve by student Id from student_base
        public Student getStudent(int StudentId)
        {
            StudentDb temp = new StudentDb();
            Student student = temp.RetrieveStudent(StudentId);
            return student;

        }

        //retrieve the data from database
        public Student ConfirmDelete(int StudentId)
        {
   
            StudentDb students = new StudentDb();
            return students.RetrieveStudent(StudentId);
           
        }

        public List<Student> GetStudentsByPercentage(string operation,float percentage)
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterPercentage(operation, percentage);
            return students;
        }
        public List<Student> GetStudentsByCgpa(string operation, float cgpa)
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCgpa(operation, cgpa);
            return students;
        }
        public List<Student> GetStudentsByCompany(String Company)
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCompany(Company);
            return students;
        }



    }
}
