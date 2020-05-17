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
        private readonly IUsersService _usersService;

        public CourseController(
            IDBBCService dBBCService,
            IUsersService usersService)
        {
            _dBBCService = dBBCService;
            _usersService = usersService;
        }

        public IActionResult CourseList()
        {
            var dbbcs = _dBBCService.GetDBBC();
            return View(dbbcs);
        }


        public IActionResult Course(Dbbc model)
        {
            var teacher = _usersService.GetUserById(model.TeacherId);

            model.Teacher = teacher;

            return View(model);
        }
    }
}