using EduHome.Data;
using EduHome.Models.BlogRel;
using EduHome.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class BlogsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IBlogService _blogService;
        public BlogsController(AppDbContext context,
                                  IWebHostEnvironment env,
                                  IBlogService blogService)
        {
            _context = context;
            _env = env;
            _blogService = blogService;
        }
        public async Task<IActionResult> Index(int take = 3, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedBlog = await _blogService.GetBlogs(take, page);
            if(paginatedBlog == null) return NotFound();
            return View(paginatedBlog);
        }

        public async Task<IActionResult> IndexWithSideBar(int take = 4, int page = 1)
        {
            ViewData["Take"] = take;
            var paginatedBlog = await _blogService.GetBlogs(take, page);
            if (paginatedBlog == null) return NotFound();
            return View(paginatedBlog);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return BadRequest();
            Blog blog = await _blogService.GetBlogById(id);
            if (blog == null) return BadRequest();
            return View(blog);
        }
    }
}
