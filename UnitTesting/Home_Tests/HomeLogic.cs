using DataAccess_Layer.Dataaccess;
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
    public class HomeLogic
    {
        
        [TestMethod]
        public void IsLoginReturnsAdmin()
        {
            LoginDb login = new LoginDb();
            Login studentcheck = new Login();
            studentcheck.Email = "admin@gmail.com";
            studentcheck.Password = "admin";

            Assert.AreEqual(login.IsLoginValid(studentcheck), "Admin");
        }
        [TestMethod]
        public void IsLoginReturnsNotVlaid()
        {

            LoginDb login = new LoginDb();
            Login studentcheck = new Login();
            studentcheck.Email = "admin@gmail.com";
            studentcheck.Password = "admin";

            Assert.AreNotEqual(login.IsLoginValid(studentcheck), "Amin");
        }
        [TestMethod]
        public void IsLoginReturnsStudent()
        {
            LoginDb login = new LoginDb();
            Login studentcheck = new Login();
            studentcheck.Email = "180030249@gmail.com";
            studentcheck.Password = "123";

            Assert.AreEqual(login.IsLoginValid(studentcheck), "Admin");
        }
        
        [TestMethod]
        public void Logout()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Logout() as ViewResult;
           
            Assert.IsNotNull(result);
            
        }
      
    }
}
