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
    public class AdminDeleteLogic
    {
        [TestMethod]
        public void Delete()
        {
            // Arrange
            AdminDeleteController controller = new AdminDeleteController();
            // Act
            ViewResult result = controller.Delete() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        
        [TestMethod]
        public void DeletePost()
        {
            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.ConfirmDelete(123);
           
            // Assert
            Assert.IsNotNull(student.StudentName);
        }
        [TestMethod]
        public void DeleteStudent()
        {

            AdminDelete delete = new AdminDelete();
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

            // Assert
            Assert.IsTrue(delete.IsDeleted(student));
        }

    }
}
