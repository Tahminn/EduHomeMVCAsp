using EduHome.Data;
using EduHome.Models;
using EduHome.Models.TeacherRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Helpers;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.TeacherVMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;
        public TeacherService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Paginate<TeacherListVM>> GetTeachers(int take, int after, int count, int page)
        {
            try
            {
                if (take == -1)
                {
                    List<Teacher> teachers = await _context.Teachers
                    .Where(t => t.Id < after && t.IsDeleted == false)
                    .Include(t => t.TeacherDetails)
                    .Include(t => t.TeacherContactInfo)
                    .Include(t => t.TeacherSocialMedia)
                    .Include(t => t.TeacherSkills)
                    .Include(t => t.Faculty)
                    .Include(t => t.Position)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    var teachersVM = GetMapDatas(teachers);
                    int totalPage = Helper.GetPageCount(count, take);
                    Paginate<TeacherListVM> paginatedTeacher = new Paginate<TeacherListVM>(teachersVM, page, totalPage);
                    return paginatedTeacher;
                }
                else
                {
                    List<Teacher> teachers = await _context.Teachers
                    .Where(t => t.Id < after && t.IsDeleted == false)
                    .Take(take)
                    .Include(t => t.TeacherDetails)
                    .Include(t => t.TeacherContactInfo)
                    .Include(t => t.TeacherSocialMedia)
                    .Include(t => t.TeacherSkills)
                    .Include(t => t.Faculty)
                    .Include(t => t.Position)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    var teachersVM = GetMapDatas(teachers);
                    int totalPage = Helper.GetPageCount(count, take);
                    Paginate<TeacherListVM> paginatedTeacher = new Paginate<TeacherListVM>(teachersVM, page, totalPage);
                    return paginatedTeacher;
                }
            }
            catch (Exception)
            {
                throw;
            }
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
        public async Task<TeacherDetailsVM> GetTeacherDetailsById(int id)
        {
            try
            {
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
                TeacherDetailsVM teacherDetailsVM = new TeacherDetailsVM()
                {
                    Teacher = teacher,
                    TeacherSkills = teacherSkills
                };
                return teacherDetailsVM;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
