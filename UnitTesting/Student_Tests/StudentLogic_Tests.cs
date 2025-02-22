using Bussiness_Layer.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Placements.Controllers;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTesting
{
    [TestClass]
    public class StudentLogic_Tests
    {
        [TestMethod]
        public void IsLoginReturnsAnyView()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Login() as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void IsRegisterReturnsAnyView()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Register() as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void IsStudentDetailsReturnsAnyView()
        {
            // Arrange
            StudentController controller = new StudentController();
            // Act
            ViewResult result = controller.StudentDetails() as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
     
        [TestMethod]
        public void StudentRegisterReturnsTrue()
        {
            StudentLogic studentcheck = new StudentLogic();
            Student student = new Student();
            student.StudentId = 123;
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



            Assert.AreEqual(studentcheck.IsAlreadyRegistered(student), true);
        }
        [TestMethod]
        public void StudentDetailsReturnsTrue()
        {
            StudentRetrieve getStudent = new StudentRetrieve();
            Student student = getStudent.GetStudentDetails("123@gmail.com");


            Assert.IsNotNull(student.StudentName);

        }
        [TestMethod]
        public void StudentDetailsIsAlreadypresentReturnsTrue()
        {
            StudentLogic studentcheck = new StudentLogic();
            Student student = new Student();
            student.StudentId = 123;
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

            Assert.IsTrue(studentcheck.IsRegistered(student));

        }
    }
    }
