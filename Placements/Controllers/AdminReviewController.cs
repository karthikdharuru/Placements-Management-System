using Bussiness_Layer.Logic;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Placements.Views.Admin
{
    public class AdminReviewController : Controller
    {

        [Authorize(Roles = "Admin")]
        public ActionResult ReviewStudent()
        {
            return View("Review");
        }
        [HttpPost]
        // retrieve student details by studentid if id in database
        public ActionResult ReviewStudent(int StudentId)
        {
            AdminLogic admin = new AdminLogic();
            if (admin.CheckStudentId(StudentId))
            {

                return RedirectToAction("edit", new { StudentId = StudentId });
            }
            else
            {
                ModelState.AddModelError("", "No student Found With Id no " + StudentId);
                return View("Review");
            }
        }

        [Authorize(Roles = "Admin")]
        [OutputCache(Duration = 60, VaryByParam = "StudentId")]
        //retrieve the student details and make it editable
        public ActionResult Edit(int StudentId)
        {

            AdminRetrieve retrieve = new AdminRetrieve();
            Student student = retrieve.getStudent(StudentId);
            if (student != null)
            {
                ViewBag.tittle = "Review";
                return View(student);
            }
            else
            {
                throw new Exception();
            }


        }
        [HttpPost]
        // update the  details changed by the admin
        public ActionResult Edit(Student student)
        {

            AdminLogic admin = new AdminLogic();
            if (admin.Isupdated(student))
            {
                return View("sucessfullyupdated");
            }
            else
            {
                throw new Exception();
            }

        }
    }
}