using Bussiness_Layer.Logic;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Placements.Controllers
{
    public class AdminFilterController : Controller
    {
       

        [Authorize(Roles = "Admin")]
        
        ///main view of filter
        public ActionResult filter()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult filterpercentage()
        {
            return View("filterbypercentage");
        }
        [HttpPost]

        [OutputCache(Duration = 60, VaryByParam = "operation;Percentage")]
        //filter students by percentage and operation provided
        public ActionResult filterpercentage (string operation, float percentage)
        {
            
            AdminRetrieve retrieve = new AdminRetrieve();
            List<Student> students = retrieve.GetStudentsByPercentage(operation, percentage);
            //if students found
            if (students.Count() > 0)
            {
                return View(students);
            }
            //not found
            else
            {
                ModelState.AddModelError("", "No Student Found Having Percentage " + operation + " " + percentage);
                return View("filterbypercentage");
            }

        }
        


        [Authorize(Roles = "Admin")]
        
        public ActionResult filterCgpa()
        {

            return View("filterbycgpa");
        }
        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "operation;Cgpa")]
        //filter students by cgpa and operation provided
        public ActionResult filterCgpa(string operation, float cgpa)
        {

            AdminRetrieve retrieve = new AdminRetrieve();
            List<Student> students = retrieve.GetStudentsByCgpa(operation, cgpa);
            //if students found
            if (students.Count() > 0)
            {
                return View(students);
            }
            //not found
            else
            {
                ModelState.AddModelError("", "No Student Found Having Cgpa " + operation + " " + cgpa);
                return View("filterbycgpa");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult filtercompany()
        {

            return View("filterbycompany");
        }
        [HttpPost]
         //filter students by company
        [OutputCache(Duration = 60, VaryByParam = "company")]
        public ActionResult filtercompany(string company)
        {


            AdminRetrieve retrieve = new AdminRetrieve();
            List<Student> students = retrieve.GetStudentsByCompany(company);
            //if students found
            if (students.Count() > 0)
            {
               
                return View(students);
            }
            //not found
            else
            {
                ModelState.AddModelError("", "No company found with name " + company);
                return View("filterbycompany");
            }

        }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewStudent(int StudentId)
        {

            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.getStudent(StudentId);

            if (student != null)
            {
                return PartialView(student);
            }
            else
            {
                throw new Exception();
            }
        }

    }
}