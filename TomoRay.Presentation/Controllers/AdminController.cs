using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Domain.Static;
using TomoRay.Presentation.Models.Admin;

namespace TomoRay.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var users = await _userService.GetAllAsync();

            var model = new AdminDashboardViewModel
            {
                TotalUsers = users.Count(),
                TotalSupervisors = users.Count(u => u.Role == UserRole.Supervisor),
                TotalStaff = users.Count(u => u.Role == UserRole.Staff),
                UnapprovedUsers = users.Where(u => !u.IsApproved).ToList(),
                RecentUsers = users.OrderByDescending(u => u.CreatedAt).Take(5).ToList() // Assuming CreatedAt is in BaseEntity
            };

            return View(model);
        }

    }
}
