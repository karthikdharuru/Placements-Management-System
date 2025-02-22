using Microsoft.VisualStudio.TestTools.UnitTesting;
using Placements.Controllers;
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
        public void Logout()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Logout() as ViewResult;
           
            Assert.IsNotNull(result);
            
        }
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
