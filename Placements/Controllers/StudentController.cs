using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Placements_Model.Models;
using System.Web.Security;
using DataAccess_Layer.Dataaccess;
using Bussiness_Layer.Logic;

namespace Placements.Controllers
{
    public class StudentController : Controller
    {
       
        //retrieve the details from student database and make them editable
        [Authorize(Roles = "Student")]
        public ActionResult StudentDetails()
        {
            
            StudentRetrieve getStudent = new StudentRetrieve();
            Student student = getStudent.GetStudentDetails(User.Identity.Name);
            
            if (student!=null)
            {
                ViewBag.tittle = "Student Details";
                return View("edit", student);
            }
            else
            {
                throw new Exception();
            }
          
        }
        [HttpPost]
        //once student submit edited details. it will update after admin approval
        public ActionResult StudentDetails(Student student)
        {
            StudentLogic studentcheck = new StudentLogic();
            if(studentcheck.IsRegistered(student))
            {
                return View("RequestedChanges");
            }
           
           else
            {
                ModelState.AddModelError("", "Request already submitted.Please wait until admin accept your changes");
                return View("edit",student);
            }
            
        }
    }
}