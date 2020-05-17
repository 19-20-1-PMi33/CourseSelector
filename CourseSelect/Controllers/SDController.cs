using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourseSelect.Controllers
{
    public class SDController : Controller
    {
        private readonly IDBBCService _dBBCService;
        private readonly IDBBCToUserService _dBBCToUserService;
        private readonly IUsersService _usersService;

        public SDController(
            IDBBCService dBBCService,
            IDBBCToUserService dBBCToUserService,
            IUsersService usersService)
        {
            _dBBCService = dBBCService;
            _dBBCToUserService = dBBCToUserService;
            _usersService = usersService;
        }

        [Route("Fill")]
        [HttpPost]
        public async Task Fill()
        {
            List<AspNetUsers> users = new List<AspNetUsers>()
            {
                new AspNetUsers()
                {
                    UserName = "Jhon",
                    Email = "123456@gmail.com",
                    Credit = "Student",
                    Surname = "Wilson",
                    PasswordHash = "AQAAAAEAACcQAAAAEDPwXXx3p9qMfLYoDG5yhJQ3/CEjPCgp5dxH3BoLi6Oa7FdcoNRrjnD1CnFmnsgV9A=="
                },
                new AspNetUsers()
                {
                    UserName = "Teacher",
                    Email = "654321@gmail.com",
                    Credit = "Teacher",
                    Surname = "Wilson",
                    PasswordHash = "AQAAAAEAACcQAAAAEDPwXXx3p9qMfLYoDG5yhJQ3/CEjPCgp5dxH3BoLi6Oa7FdcoNRrjnD1CnFmnsgV9A=="
                },
            };

            foreach (var item in users)
            {
                _usersService.AddUser(item);
            }

            await _usersService.Save();

            var student = _usersService.GetUsers().FirstOrDefault(x => x.Credit == users[0].Credit);
            var teacher = _usersService.GetUsers().FirstOrDefault(x => x.Credit == users[1].Credit);

            List<Dbbc> dbbcs = new List<Dbbc>()
            {
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "Psihology: This is beatiful thing",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 20,
                    NumberSetsUsed = 1
                },
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "Awakening: Abstergo is bad organisation",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 30,
                    NumberSetsUsed = 1
                }
            };

            foreach (var item in dbbcs)
            {
                _dBBCService.AddDBBC(item);
            }

            await _dBBCService.Save();

            var firstDbbc = _dBBCService.GetDBBC().First(x => x.Description.Split(':')[0] == "Psihology");

            List<Dbbctouser> dbbctousers = new List<Dbbctouser>()
            {
                new Dbbctouser()
                {
                    UserId = student.Id,
                    Dbbcid = firstDbbc.Id
                }
            };

            foreach (var item in dbbctousers)
            {
                _dBBCToUserService.AddDBBCToUser(item);
            }

            await _dBBCToUserService.Save();
        }
    }
}