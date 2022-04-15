using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
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

        public async Task<IActionResult> Index(int take = 3, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedTeacher = await _teacherService.GetTeachers(take, page);
            if (paginatedTeacher == null) return NotFound();
            return View(paginatedTeacher);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var teacher = await _teacherService.GetTeacherDetailsById(id);
            if (teacher is null) return NotFound();
            return View(teacher);
        }
    }
}
