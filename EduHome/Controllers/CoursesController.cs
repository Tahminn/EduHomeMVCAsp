using Domain.Data;
using Domain.Entities.CourseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
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
        public async Task<IActionResult> Index(int take = 3, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedCourses = await _courseService.GetCourses(take, page);
            if (paginatedCourses == null) return NotFound();
            return View(paginatedCourses);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return BadRequest();
            Course course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest();
            return View(course);
        }
    }
}
