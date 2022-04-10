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
            var courseCount = await _context.Courses.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = courseCount;
            ViewData["CourseCount"] = courseCount;
            ViewData["Take"] = take;
            List<Course> courses = await _courseService.GetCourses(take,after);
            int totalPage = Helper.GetPageCount(courseCount, take);
            Paginate<Course> paginatedCourse = new Paginate<Course>(courses, page, totalPage);
            return View(paginatedCourse);
        }
        public async Task<IActionResult> Details(int id)
        {
            if(id == 0) return BadRequest();
            Course course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest();
            return View(course);
        }
        //private List<CourseVM> GetMapDatas(List<Course> courses)
        //{
        //    List<CourseVM> mapDatas = new List<CourseVM>();
        //    foreach (var course in courses)
        //    {
        //        CourseVM mapData = new CourseVM()
        //        {
        //            Id = course.Id,
        //            Category = course.Category.Name,
        //            Description = course.Description,
        //            Images = (ICollection<string>)course.CourseImages
        //        };
        //        mapDatas.Add(mapData);
        //    }
        //    return mapDatas;
        //}
    }
}
