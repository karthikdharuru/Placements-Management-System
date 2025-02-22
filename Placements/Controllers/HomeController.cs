using Bussiness_Layer.Logic;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Placements.Controllers
{
   
    public class HomeController : Controller
    {

        // GET: StudentLogin
        [AllowAnonymous]
        public ActionResult Login()
        {

            //if student already registered and logged in redirect to student main page 

            StudentLogic student = new StudentLogic();
            AdminLogic admin = new AdminLogic();
            if (student.IsAlreadyLoggedIn())
            {
                return RedirectToAction("StudentDetails", "student");
            }
            //if the user is logged in as admin redirect to admin main page
            else if (admin.IsAlreadyLoggedIn())
            {
                return RedirectToAction("index", "admin");
            }
            //else display login page 
            else
            {
                return View();
            }

        }
        [HttpPost]
        //checking whether student provided valid details or not
        public ActionResult Login(Login login)
        {
            HomeLogic user = new HomeLogic();
            string role = user.IsLoginValid(login);
            if(role == "Student")
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);
                return RedirectToAction("StudentDetails","student");
            }
            else if (role == "Admin")
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);
                return RedirectToAction("index", "admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
        }

        //if student already logged in he cannot register again

        public ActionResult Register()
        {
            //if student already registered and logged in redirect to student main page 

            StudentLogic student = new StudentLogic();
            AdminLogic admin = new AdminLogic();
            if (student.IsAlreadyLoggedIn())
            {
                return RedirectToAction("StudentDetails", "student");
            }
            //if the user is logged in as admin redirect to admin main page
            else if (admin.IsAlreadyLoggedIn())
            {
                return RedirectToAction("index", "admin");
            }

            else
            {

                return View();
            }

        }
        [HttpPost]
        //if student wishes to register student can fill the details and request admin to approve registration
        public ActionResult Register(Student student)
        {
            StudentLogic studentcheck = new StudentLogic();
            if (studentcheck.IsAlreadyRegistered(student))
            {
                ModelState.AddModelError("", "Student Already registered");
                return View();
            }
            else
            {
                if (studentcheck.IsRegistered(student))
                {
                    return View("Registered");
                }
                else
                {
                    throw new Exception();
                }
            }

        }
       

        [Authorize(Roles = "Student,Admin")]

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
           

            return View("Logout");
        }
    }
}