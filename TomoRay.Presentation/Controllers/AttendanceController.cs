using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TomoRay.Application.Common.Interfaces.Services;
using TomoRay.Domain.Entities;
using TomoRay.Presentation.Models;
using System.Text.RegularExpressions;

namespace TomoRay.Presentation.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AttendanceController(
            IAttendanceService attendanceService,
            IWebHostEnvironment webHostEnvironment)
        {
            _attendanceService = attendanceService;
            _webHostEnvironment = webHostEnvironment;
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

            var attendance = new Attendance
            {
                UserId = model.UserId,
                MarkedAt = DateTime.Now,
                LocationAddress = model.LocationAddress ?? $"{model.Latitude}, {model.Longitude}",
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                PhotoUrl = "/images/" + fileName,
                Remarks = model.Remarks
            };

            await _attendanceService.MarkAttendanceAsync(attendance);

            TempData["Success"] = "Attendance marked successfully!";
            return RedirectToAction("Index");
        }

        // GET: Attendance/Index (optional - to list all records)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _attendanceService.GetAllAsync();
            return View(list);
        }
    }
}
