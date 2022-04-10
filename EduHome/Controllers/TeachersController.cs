using EduHome.Data;
using EduHome.Models;
using EduHome.Models.TeacherRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Pagination;
using EduHome.Utilities.Helpers;
using EduHome.ViewModels.TeacherVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ITeacherService _teacherService;
        public TeachersController(AppDbContext context,
                                  IWebHostEnvironment env,
                                  ITeacherService teacherService)
        {
            _context = context;
            _env = env;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index(int after, int take = 3, int page = 1)
        {
            var count = await _context.Teachers.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = count;
            ViewData["TeacherCount"] = count;
            ViewData["TakeTeacher"] = take;
            var paginatedTeacher = await _teacherService.GetTeachers(take, after, count, page);
            return View(paginatedTeacher);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var teacherDetails = await _teacherService.GetTeacherDetailsById(id);
            if (teacherDetails is null) return NotFound(); 
            return View(teacherDetails);
        }
    }
}
