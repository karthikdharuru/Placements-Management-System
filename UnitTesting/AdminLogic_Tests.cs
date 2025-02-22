using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Placements_Model.Models;
using Bussiness_Layer.Logic;
using Placements.Controllers;
using System.Web.Mvc;

namespace UnitTesting
{
    [TestClass]
    public class AdminLogic_Tests
    {


        [TestMethod]
        public void AdminLoginReturnsTrue()
        {
            AdminLogic adminlogin = new AdminLogic();
            AdminLogin admin = new AdminLogin();
            admin.AdminId = "admin";
            admin.AdminPassword = "admin";
            bool Isloggedin = adminlogin.Login(admin);

            Assert.AreEqual(Isloggedin, true);
        }

        [TestMethod]
        public void AdminLoginReturnsFalse()
        {
            AdminLogic adminlogin = new AdminLogic();
            AdminLogin admin = new AdminLogin();
            admin.AdminId = "admin";
            admin.AdminPassword = "123";
            bool Isloggedin = adminlogin.Login(admin);

            Assert.AreEqual(Isloggedin, false);
        }
        [TestMethod]
        public void Login()
        {
            // Arrange
            AdminController controller = new AdminController();
            // Act
            ViewResult result = controller.Login() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void AddStudent()
        {
            // Arrange
            AdminController controller = new AdminController();
            // Act
            ViewResult result = controller.AddStudent() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ISAdded()
        {
            Admininsert admin = new Admininsert();
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
            Assert.AreEqual(admin.IsAdded(student), true);
        }



    }

}
