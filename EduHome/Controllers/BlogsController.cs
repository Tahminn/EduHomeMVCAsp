using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class BlogsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> BlogDetails(int Id)
        {
            return View();
        }
        public async Task<IActionResult> BlogSideBar()
        {
            return View();
        }
    }
}
