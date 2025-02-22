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
    public class AdminRegisterLogic
    {
        [TestMethod]
        public void RegisterReturnsWhichView()
        {

            AdminRetrieve retrieve = new AdminRetrieve();
            List<Student> students = retrieve.getStudents();

            Assert.AreNotEqual(0, students.Count() > 0);

        }
        [TestMethod]
        public void IsRegisterReturnsAnyView()
        {
            // Arrange
            AdminRegisterController controller = new AdminRegisterController();
            // Act
            ViewResult result = controller.Register() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        
        }
        [TestMethod]
        public void IsAcceptOrDenyStudentReturnsAnyView()
        {
            // Arrange
            AdminRegisterController controller = new AdminRegisterController();
            // Act
            ViewResult result = controller.AcceptOrDenyStudent(123) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void IsAcceptReturnsAnyView()
        {
            // Arrange
            AdminRegisterController controller = new AdminRegisterController();
            // Act
            ViewResult result = controller.Accept(123) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void IsRejectReturnsAnyView()
        {
            // Arrange
            AdminRegisterController controller = new AdminRegisterController();
            // Act
            ViewResult result = controller.Reject(123) as ViewResult;
            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void AcceptOrDenyStudentReturnsTrue()
        {
            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.getStudentFromTemp(1572105800);

            // Assert
            Assert.IsNotNull(student.StudentName);

        }
        [TestMethod]
        public void AcceptReturnsTrue()
        {
            AdminLogic admin = new AdminLogic();
            bool Issucess = admin.Isaccepted(12915116);
            // Assert
            Assert.IsTrue(Issucess);

        }
        [TestMethod]
        public void RejectReturnsTrue()
        {
            AdminDelete delete = new AdminDelete();
            bool Isrejected = delete.IsRejected(12915116);

            // Assert
            Assert.IsTrue(Isrejected);

        }


    }
}
