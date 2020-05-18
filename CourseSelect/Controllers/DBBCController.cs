using Microsoft.AspNetCore.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CourseSelect.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Subscribe(int dbbcId)
        {
            Dbbctouser dbbctouser = new Dbbctouser()
            {
                Dbbcid = dbbcId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var dbbcsToUser = _dBBCToUserService.GetUsersDbbcByUserId(dbbctouser.UserId);

            var result = _dBBCService.IncrementById(dbbcId);

            if (result)
            {
                await _dBBCService.Save();

                _dBBCToUserService.AddDBBCToUser(dbbctouser);
                await _dBBCToUserService.Save();
            }

            return RedirectToAction("CourseList", "Course");
        }
    }
}