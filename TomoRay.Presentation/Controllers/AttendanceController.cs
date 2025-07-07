using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Domain.Entities;
using TomoRay.Presentation.Models;
using System.Text.RegularExpressions;
using System.Security.Claims;
using TomoRay.Application.Common.Interfaces;

namespace TomoRay.Presentation.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController(IWebHostEnvironment webHostEnvironment,IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult Mark()
        {
            var model = new MarkAttendanceViewModel(); // <-- important
            return View(model); // pass model here
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mark(MarkAttendanceViewModel model)
        {
            if (string.IsNullOrEmpty(model.PhotoBase64))
            {
                ModelState.AddModelError("PhotoBase64", "Please capture a photo.");
                return View(model);
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string fileName = Guid.NewGuid().ToString() + ".png";
            string filePath = Path.Combine(uploadsFolder, fileName);

            var base64Data = Regex.Match(model.PhotoBase64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] imageBytes = Convert.FromBase64String(base64Data);
            System.IO.File.WriteAllBytes(filePath, imageBytes);

            // 🟢 Authenticated user ka ID lena
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);


            //replace this with mapping in future!
            var attendance = new Attendance
            {
                UserId = userId, // 🔥 Yehi sahi hai
                MarkedAt = DateTime.Now,
                LocationAddress = model.LocationAddress ?? $"{model.Latitude}, {model.Longitude}",
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                PhotoUrl = "/images/" + fileName,
                Remarks = model.Remarks
            };

            await _unitOfWork.AttendanceServiceUOW.MarkAttendanceAsync(attendance);

          TempData["Success"] = "Attendance Marked Successfully!";
            return RedirectToAction("Mark");
        }


        // GET: Attendance/Index (optional - to list all records)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _unitOfWork.AttendanceServiceUOW.GetAllAsync();
            return View(list);
        }
    }
}
