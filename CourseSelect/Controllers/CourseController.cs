using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseSelect.Controllers
{   
    //[Authorize]
    public class CourseController : Controller
    {
        public IActionResult CourseList()
        {
            return View();
        }
    }
}