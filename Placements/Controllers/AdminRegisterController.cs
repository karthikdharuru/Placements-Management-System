using Bussiness_Layer.Logic;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Placements.Controllers
{
    public class AdminRegisterController : Controller
    {
        //retrieve details of students who are requested to register or edit their details
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            AdminRetrieve retrieve = new AdminRetrieve();
            List<Student> students = retrieve.getStudents();
            if (students.Count() > 0)
            {
                return View(students);
            }
            else
            {
                return View("NoStudent");
            }



        }
        [Authorize(Roles = "Admin")]

        public ActionResult AcceptOrDenyStudent(string Email)
        {

            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.getStudentFromTemp(Email);
            if(student!=null)
            {
                return View(student);
            }
            else
            {
                return RedirectToAction("Register");
            }

            
        }
        //retrieve student details from temp database add to student to student database and delete details from temp database
        [Authorize(Roles = "Admin")]
        public ActionResult Accept(string Email)
        {


            AdminLogic admin = new AdminLogic();
            bool Issucess = admin.Isaccepted(Email);
            if (Issucess == true)
            {
                TempData[Email] = "Your Details Are Updated";

                return RedirectToAction("Register");
            }
            else
            {
                return RedirectToAction("acceptordeny", Email);
            }

        }
        [Authorize(Roles = "Admin")]
        //reject the request made by student
        public ActionResult Reject(string Email)
        {
            AdminDelete delete = new AdminDelete();
            bool Isrejected = delete.IsRejected(Email);
            if (Isrejected)
            {
                TempData[Email] = "Your Details Are Rejected";
                return RedirectToAction("Register");
            }
            else
            {
                return View("acceptordenystudent", Email);
            }

        }
    }
}