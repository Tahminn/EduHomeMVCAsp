//using EduHome.Data;
//using EduHome.Models.BlogRel;
//using EduHome.Services.Interfaces;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EduHome.Controllers
//{
//    public class BlogsController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;
//        private readonly IBlogService _blogService;
//        public BlogsController(AppDbContext context,
//                                  IWebHostEnvironment env,
//                                  IBlogService blogService)
//        {
//            _context = context;
//            _env = env;
//            _blogService = blogService;
//        }
//        public async Task<IActionResult> Index(int after, int take = 3, int page = 1)
//        {
//            //var lastBlog = _context.Blogs.OrderByDescending(t => t.Id).ToArray();
//            //int lastId = lastBlog[0].Id + 1;
//            //if (after == 0) after = lastId;
//            //var count = await _context.Blogs.Where(b => !b.IsDeleted).AsNoTracking().CountAsync();
//            var paginatedBlogs = await _blogService.GetBlogs(take, after, page);
//            //after = paginatedBlogs.DatasAll.ElementAtOrDefault((page - 1) * take).Id;
//            //ViewData["BlogCount"] = paginatedBlogs.DataCount + 1;
//            ViewData["Take"] = take;
//            ViewData["After"] = after;
//            return View(paginatedBlogs);
//        }
//        public async Task<IActionResult> IndexWithSideBar(int after, int take = 3, int page = 1)
//        {
//            var lastBlog = _context.Blogs.OrderByDescending(t => t.Id).First();
//            int lastId = lastBlog.Id;
//            if (after == 0) after = lastId + 1;
//            var count = await _context.Blogs.Where(b => !b.IsDeleted).AsNoTracking().CountAsync();
//            ViewData["BlogCount"] = count + 1;
//            ViewData["Take"] = take;
//            var paginatedBlogs = await _blogService.GetBlogs(take, after, page);
//            return View(paginatedBlogs);
//        }
//        public async Task<IActionResult> Details(int id)
//        {
//            if (id == 0) return BadRequest();
//            Blog blog = await _blogService.GetBlogById(id);
//            if (blog == null) return BadRequest();
//            return View(blog);
//        }
//    }
//}
