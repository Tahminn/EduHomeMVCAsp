using Domain;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace EduHome.Areas.EduHomeAdmin.Controllers
{
    [Area("EduHomeAdmin")]
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

        public async Task<IActionResult> Index(int take, int page = 1)
        {
            ViewData["TakeTeacher"] = take;
            var paginatedTeacher = await _teacherService.GetTeachers(take, page);
            if (paginatedTeacher == null) return NotFound();
            return View(paginatedTeacher);
        }
    }
}
