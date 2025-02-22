using Bussiness_Layer.Logic;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Placements.Controllers
{
    public class AdminDeleteController : Controller
    {
        [Authorize(Roles = "Admin")]
        //delete student
        public ActionResult Delete()
        {

            return View("DeleteStudent");
        }
        [HttpPost]
        //get the student id and check whether student exists or not
        public ActionResult Delete(int StudentId)
        {
            if (ModelState.IsValid)
            {
                //if student exists on submit redirect to delete student
                AdminRetrieve retrieve = new AdminRetrieve();
                Student student = retrieve.ConfirmDelete(StudentId);
                if (student != null)
                {

                    TempData["student"] = student;
                    TempData.Keep("student");
                    return View(student);
                }
                //throw error
                else
                {
                    ModelState.AddModelError("", "No student Found With Id " + StudentId);
                    return View("deletestudent");
                }
            }
            else
            {
                return View();
            }

        }

        [Authorize(Roles = "Admin")]
        //delete the student from student database if data exists
        public ActionResult Deletestudent()
        {
            if (TempData["student"] != null)
            {
                Student student = TempData["student"] as Student;
                AdminDelete delete = new AdminDelete();
                delete.IsDeleted(student);
                return View("Deleted");
            }
            else
            {
                return RedirectToAction("index", "admin");
            }
        }
    }
}