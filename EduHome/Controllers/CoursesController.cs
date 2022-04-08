using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> CourseDetails(int Id)
        {
            return View();
        }
        public async Task<IActionResult> CourseSideBar()
        {
            return View();
        }
    }
}
