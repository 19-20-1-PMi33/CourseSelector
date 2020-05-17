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


        public IActionResult Course(string description, string endDate, string startDate, string numberOfSeats, string numberOfSeatsUsed, string teacherId)
        {
            var teacher = _usersService.getUserById(Convert.ToInt32(teacherId));

            var model = new Dbbc()
            {
                Description = description,
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate),
                NumberOfSeats = Convert.ToInt32(numberOfSeats),
                NumberSetsUsed = Convert.ToInt32(numberOfSeatsUsed)
            };

            return View(model);
        }
    }
}