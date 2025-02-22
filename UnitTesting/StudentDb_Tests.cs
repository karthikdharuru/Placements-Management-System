using Bussiness_Layer.Logic;
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
    public class StudentDb_Tests
    {
        [TestMethod]
        public void IsStudentReturnsTrue()
        {
           StudentDb student= new StudentDb();
            StudentLogin studentcheck = new StudentLogin();
              
            Assert.IsTrue(student.IsStudent(13,"123"));
        }
        [TestMethod]
        public void IsAdminReturnsFalse()
        {
            StudentDb student = new StudentDb();
            StudentLogin studentcheck = new StudentLogin();

            Assert.IsFalse(student.IsStudent(123, "1234"));
        }
        [TestMethod]
        public void RetrieveStudentReturnsTrue()
        {
            StudentDb studentdb = new StudentDb();
            Student student = studentdb.RetrieveStudent(123);

            Assert.IsNotNull(student.StudentName);
        }
        [TestMethod]
        public void RetrieveStudentReturnsFalse()
        {
            StudentDb studentdb = new StudentDb();
            Student student = studentdb.RetrieveStudent(132);

            Assert.IsNull(student.StudentName);
        }
        [TestMethod]
        public void RetrievePlacedReturnsTrue()
        {
            StudentDb studentdb = new StudentDb();
            Student student = new Student();
             student = studentdb.retrieveplaceddetails(13,student);

            Assert.IsTrue(student.Company!=null&&student.Package!=0);
        }
        [TestMethod]
        public void RetrievePlacedReturnsFalse()
        {
            StudentDb studentdb = new StudentDb();
            Student student = new Student();
            student = studentdb.retrieveplaceddetails(123000, student);

            Assert.IsFalse(student.Company != null && student.Package != 0);
        }


    }
}
