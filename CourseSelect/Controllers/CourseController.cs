using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{   
    [Authorize]
    public class CourseController : Controller
    {
        private readonly IDBBCService _dBBCService;

        public CourseController(IDBBCService dBBCService)
        {
            _dBBCService = dBBCService;
        }

        public IActionResult CourseList()
        {
            var dbbcs = _dBBCService.GetDBBC();
            return View(dbbcs);
        }

        public IActionResult Course(Dbbc model)
        {
            return View(model);
        }
    }
}