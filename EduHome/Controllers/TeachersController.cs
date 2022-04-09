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

        public async Task<IActionResult> Index(int after, int takeTeacher = 3, int page = 1)
        {
            var teacherCount = await _context.Teachers.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = teacherCount;
            ViewData["TeacherCount"] = teacherCount;
            ViewData["TakeTeacher"] = takeTeacher;
            var teachers = await _teacherService.GetTeachers(takeTeacher, after);
            var teachersVM = GetMapDatas(teachers);
            int totalPage = Helper.GetPageCount(teacherCount, takeTeacher);
            Paginate<TeacherListVM> paginatedTeacher = new Paginate<TeacherListVM>(teachersVM, page, totalPage);
            return View(paginatedTeacher);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            List<TeacherSkill> teacherSkills = await _context.TeacherSkills
                .Where(ts => ts.TeacherId == id)
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Skill)
                .ToListAsync();
            Teacher teacher = await _context.Teachers
                .Where(t => t.Id == id)
                .Include(t => t.TeacherDetails)
                .Include(t => t.TeacherContactInfo)
                .Include(t => t.TeacherSocialMedia)
                .Include(t => t.TeacherSkills)
                .Include(t => t.Faculty)
                .Include(t => t.Position)
                .FirstOrDefaultAsync();
            if (teacher == null) return NotFound();
            TeacherDetailsVM teacherDetailsVM = new TeacherDetailsVM()
            {
                Teacher = teacher,
                TeacherSkills = teacherSkills
            };
            return View(teacherDetailsVM);
        }

        private List<TeacherListVM> GetMapDatas(List<Teacher> teachers)
        {
            List<TeacherListVM> mapDatas = new List<TeacherListVM>();
            foreach (var teacher in teachers)
            {
                TeacherListVM mapData = new TeacherListVM()
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Image = teacher.TeacherDetails.Image,
                    Position = teacher.Position.Name,
                    About = teacher.TeacherDetails.About,
                    Degree = teacher.TeacherDetails.Degree,
                    Experience = teacher.TeacherDetails.Experience,
                    Hobbies = teacher.TeacherDetails.Hobbies,
                    Faculty = teacher.Faculty.Name,
                    Email = teacher.TeacherContactInfo.Email,
                    PhoneNumber = teacher.TeacherContactInfo.PhoneNumber,
                    Skype = teacher.TeacherSocialMedia.Skype,
                    Facebook = teacher.TeacherSocialMedia.Facebook,
                    Pinterest = teacher.TeacherSocialMedia.Pinterest,
                    Instagram = teacher.TeacherSocialMedia.Instagram,
                    Twitter = teacher.TeacherSocialMedia.Twitter
                };
                mapDatas.Add(mapData);
            }
            return mapDatas;
        }
    }
}
