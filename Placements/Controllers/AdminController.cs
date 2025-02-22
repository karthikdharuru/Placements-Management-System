using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using Placements_Model.Models;
using DataAccess_Layer.Dataaccess;
using Bussiness_Layer.Logic;
namespace Placements.Controllers
{

    public class AdminController : Controller
    {
        

        //main page of admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        //adding of student
        [Authorize(Roles = "Admin")]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        //addstudent check if student already registered if not registered add the student
        public ActionResult AddStudent(Student student)
        {
            Admininsert admin = new Admininsert();
            if (ModelState.IsValid)
            {
                if (admin.IsAdded(student))
                {
                    return View("successfullyadded");

                }
                else
                {
                    ModelState.AddModelError("", "Student Already Exists");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }

       
    
}