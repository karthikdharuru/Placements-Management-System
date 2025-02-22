using Bussiness_Layer.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Placements.Views.Admin;
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
    public class AdminReviewLogic
    {
        [TestMethod]
        public void IsReviewStudentReturnsAnyView()
        {
            // Arrange
            AdminReviewController controller = new AdminReviewController();
            // Act
            ViewResult result = controller.ReviewStudent(123) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void IsEditReturnsAnyView()
        {
            // Arrange
            AdminReviewController controller = new AdminReviewController();
            // Act
            ViewResult result = controller.Edit(123) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
       
        [TestMethod]
        public void ReviewStudentReturnsReviewView()
        {

            AdminLogic admin = new AdminLogic();
            
                Assert.IsTrue(admin.CheckStudentId(123));

        }
        [TestMethod]
        
        public void EditReturnsEditView()
        {
            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.getStudent(123);
            Assert.IsNotNull(student.StudentName);

        }
        [TestMethod]
        [HttpPost]
        public void EditReturnsSuccessfulyysubmitedView()
        {
            AdminLogic admin = new AdminLogic();
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
            Assert.IsNotNull(admin.Isupdated(student));

        }
    }
}
