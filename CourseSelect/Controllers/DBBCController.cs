using Microsoft.AspNetCore.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

namespace CourseSelect.Controllers
{
    public class DBBCController : Controller
    {
        private readonly IDBBCToUserService _dBBCToUserService;
        private readonly IDBBCService _dBBCService;

        public DBBCController(
            IDBBCToUserService dBBCToUserService,
            IDBBCService dBBCService)
        {
            _dBBCToUserService = dBBCToUserService;
            _dBBCService = dBBCService;
        }

        public IActionResult Subscribe(int dbbcId)
        {
            Dbbctouser dbbctouser = new Dbbctouser()
            {
                Dbbcid = dbbcId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            _dBBCToUserService.AddDBBCToUser(dbbctouser);
            _dBBCToUserService.Save();

            return View();
        }
    }
}