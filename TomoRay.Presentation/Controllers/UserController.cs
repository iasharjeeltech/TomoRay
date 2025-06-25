using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Domain.Entities;
using TomoRay.Domain.Static;
using TomoRay.Presentation.Models;

namespace TomoRay.Presentation.Controllers
{
    public class UserController : Controller
        {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                Email = model.Email.ToLower(),
                PhoneNumber = model.PhoneNumber,
                Role = model.Role,
                IsApproved = true
            };

            await _userService.RegisterAsync(user, model.Password);

            TempData["Success"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.LoginAsync(model.Email.ToLower(), model.Password);

            if (user == null)
            {
                Console.WriteLine("Login failed for email: " + model.Email);
                ModelState.AddModelError(string.Empty, "Invalid credentials or user not registered.");
                return View(model);
            }
            else
            {
                Console.WriteLine("Login success for email: " + model.Email);
            }


            // Sign-in logic
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // ⭐ Redirect based on role
            switch (user.Role)
            {
                case UserRole.Admin:
                    return RedirectToAction("Dashboard", "Admin");
                case UserRole.Supervisor:
                    return RedirectToAction("Dashboard", "Supervisor");
                case UserRole.Staff:
                    return RedirectToAction("Dashboard", "Staff");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }



    }
}
