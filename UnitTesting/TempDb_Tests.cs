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
    public class TempDb_Tests
    {
        [TestMethod]
        public void AddStudentReturnsTrue()
        {
            TempStudentDb tempadmin = new TempStudentDb();
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
            Assert.AreEqual(tempadmin.RegisterStudent(student), true);

        }

        [TestMethod]
        public void YettoRegisterReturnsTrue()
        {
            TempStudentDb tempadmin = new TempStudentDb();
            
            Assert.AreEqual(tempadmin.YettORegister().Count>0, true);

        }
        [TestMethod]
        public void RetrieveStudentReturns()
        {
            TempStudentDb tempadmin = new TempStudentDb();
            Student student = tempadmin.RetrieveStudent(1572105800);
            Assert.IsNotNull(student.StudentName);

        }
        [TestMethod]
        public void RetrieveStudentReturnsNull()
        {
            TempStudentDb tempadmin = new TempStudentDb();
            Student student = tempadmin.RetrieveStudent(12915117);
            Assert.IsNull(student.StudentName);

        }
        [TestMethod]
        public void deleterReturnsFalse()
        {
            TempStudentDb tempadmin = new TempStudentDb();

            Assert.AreEqual(tempadmin.DeleteStudent(1371453747), true);

        }

    }
}
