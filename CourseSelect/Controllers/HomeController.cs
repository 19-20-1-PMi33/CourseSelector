using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;
using CourseSelect.Models;

namespace CourseSelect.Controllers
{
    public class HomeController : Controller
    {
        private List<Subjects> emp;
        public HomeController()
        {

            emp = new List<Subjects>()
            {

                new Subjects()
                {nameOfcourse="Криптологія",teacherName="Малець", studentsAmount=300, desc_href="https://ami.lnu.edu.ua/" },
                new Subjects()
                { nameOfcourse="Орфографія",teacherName="Королль", studentsAmount=500, desc_href="https://ami.lnu.edu.ua/" },
                new Subjects()
                { nameOfcourse="Батьківство",teacherName="Kальченко", studentsAmount=100, desc_href="https://ami.lnu.edu.ua/"}
            };
        }
            public ActionResult Index()
        {
            return View();
        }

        public JsonResult SubjectsData()
        {
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}