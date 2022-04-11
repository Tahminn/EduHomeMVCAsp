using EduHome.Data;
using EduHome.Models.CourseRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Helpers;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.CourseVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ICourseService _courseService;
        public CoursesController(AppDbContext context,
                                  IWebHostEnvironment env,
                                  ICourseService courseService)
        {
            _context = context;
            _env = env;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index(int after, int take = 3, int page = 1)
        {
            var count = await _context.Courses.Where(b => !b.IsDeleted).AsNoTracking().CountAsync();
            if (after == 0) after = count;
            ViewData["CourseCount"] = count + 1;
            ViewData["Take"] = take;
            var paginatedCourses = await _courseService.GetCourses(take,after, count, page);
            return View(paginatedCourses);
        }
        public async Task<IActionResult> Details(int id)
        {
            if(id == 0) return BadRequest();
            Course course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest();
            return View(course);
        } 
    }
}
