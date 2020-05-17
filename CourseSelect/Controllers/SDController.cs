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
                    Description = "Psihology: The science of behavior and mind. Psychology includes the study of conscious and unconscious phenomena, as well as feeling and thought. It is an academic discipline of immense scope. Psychologists seek an understanding of the emergent properties of brains, and all the variety of phenomena linked to those emergent properties, joining this way the broader neuro-scientific group of researchers. As a social science it aims to understand individuals and groups by establishing general principles and researching specific cases.",
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2030, 1, 1),
                    NumberOfSeats = 20,
                    NumberSetsUsed = 1
                },
                new Dbbc()
                {
                    TeacherId = teacher.Id,
                    Description = "Yoga: The practice of yoga has been thought to date back to pre-vedic Indian traditions; possibly in the Indus valley civilization around 3000 BCE. Yoga is mentioned in the Rigveda, and also referenced in the Upanishads, . Although, yoga most likely developed as a systematic study around the 5th and 6th centuries BCE, in ancient India's ascetic and śramaṇa movements. The chronology of earliest texts describing yoga-practices is unclear, varyingly credited to the Upanishads. The Yoga Sutras of Patanjali date from the 2nd century BCE, and gained prominence in the west in the 20th century after being first introduced by Swami Vivekananda. Hatha yoga texts began to emerge sometime between the 9th and 11th century with origins in tantra.",
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