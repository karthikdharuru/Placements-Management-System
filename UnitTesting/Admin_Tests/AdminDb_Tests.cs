using DataAccess_Layer.Dataaccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Placements_Model.Models;
using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class AdminDb_Tests
    {

        [TestMethod]
        public void AddStudentReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            Student student = new Student();
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            student.StudentId = i;
            student.StudentPassword = Guid.NewGuid().ToString();
            student.StudentName = "KARTHIK";
            student.Address = "2-175";
            student.Backlogs = 0;
            student.Branch = "cse";
            student.Cgpa = 9.0F;
            student.Company = "leadsqaured";
            student.DoB = DateTime.Parse("05-02-2001");
            student.Email = "abc@gmail.com";
            student.IsFessPaid = true;
            student.IsPlaced = true;
            student.Mobile = 6303263042.ToString();
            student.Package = 1234;
            student.Percentage = 12F;
            Assert.AreEqual(admin.AddStudent(student),true);

        }
        [TestMethod]
        public void UpdateStudentReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            Student student = new Student();
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            student.StudentId = 438542172;
            student.StudentPassword = "123";
            student.StudentName = "KARTHIK";
            student.Address = "2-175";
            student.Backlogs = 0;
            student.Branch = "cse";
            student.Cgpa = 9.0F;
            student.Company = "leadsqaured";
            student.DoB = DateTime.Parse("05-02-2001");
            student.Email = "abc@gmail.com";
            student.IsFessPaid = true;
            student.IsPlaced = false;
          
            student.Mobile = 6303263042.ToString();
            student.Package = 1234;
            student.Percentage = 12F;
            Assert.IsTrue(admin.UpdateStudent(student));
        }
        [TestMethod]
        public void DeleteStudentReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            Student student = new Student();

            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            student.StudentId = 438542172;
            student.StudentPassword = "123";
            student.StudentName = "KARTHIK";
            student.Address = "2-175";
            student.Backlogs = 0;
            student.Branch = "cse";
            student.Cgpa = 9.0F;
            student.Company = "leadsqaured";
            student.DoB = DateTime.Parse("05-02-2001");
            student.Email = "abc@gmail.com";
            student.IsFessPaid = true;
            student.IsPlaced = false;

            student.Mobile = 6303263042.ToString();
            student.Package = 1234;
            student.Percentage = 12F;
            Assert.IsTrue(admin.DeleteStudent(student));
        }


        [TestMethod]
        public void FilterPercentageReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterPercentage(">=", 100);
            Assert.AreEqual(0, students.Count());
        }
        [TestMethod]
        public void FilterPercentageReturnsFalse()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterPercentage("<=", 100);
            Assert.AreNotEqual(0, students.Count());
        }

        [TestMethod]
        public void FilterCgpaReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCgpa(">=", 10);
            Assert.AreEqual(0, students.Count());
        }
        [TestMethod]
        public void FilterCgpaReturnsFalse()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCgpa("<=", 10);
            Assert.AreNotEqual(0, students.Count());
        }


        [TestMethod]
        public void FilterCompanyReturnsTrue()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCompany("somecompany");
            Assert.AreEqual(0, students.Count());
        }
        [TestMethod]
        public void FilterCompanyReturnsFalse()
        {
            AdminDb admin = new AdminDb();
            List<Student> students = admin.FilterCompany("leadsquared");
            Assert.AreNotEqual(0, students.Count());
        }


    }
}
