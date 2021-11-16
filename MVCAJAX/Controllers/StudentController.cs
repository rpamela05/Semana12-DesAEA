using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using MVCAJAX.Models;
using System.Web.Mvc;
using Domain;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        // GET: Student
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             studentID = c.studentID,
                             studentAddress = c.studentAddress,
                             studentName = c.studentName
                         }).ToList();
            return View(model);
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    }
}