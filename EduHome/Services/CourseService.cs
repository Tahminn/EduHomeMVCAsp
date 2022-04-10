using EduHome.Data;
using EduHome.Models.CourseRel;
using EduHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetCourses(int take, int after)
        {
            try
            {
                if (take == -1)
                {
                    List<Course> courses = await _context.Courses
                    .Where(c => c.Id < after && !c.IsDeleted)
                    .Include(c => c.Assestment)
                    .Include(c => c.Category)
                    .Include(c => c.Language)
                    .Include(c => c.CourseImages)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    return courses;
                }
                else
                {
                    List<Course> courses = await _context.Courses
                    .Where(c => c.Id < after && !c.IsDeleted)
                    .Take(take)
                    .Include(c => c.Assestment)
                    .Include(c => c.Category)
                    .Include(c => c.Language)
                    .Include(c => c.CourseImages)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    return courses;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //List<TeacherSkill> teacherSkills = await _context.TeacherSkills
        //            .Where(ts => ts.TeacherId == id)
        //            .Include(ts => ts.Teacher)
        //            .Include(ts => ts.Skill)
        //            .ToListAsync();
        //Teacher teacher = await _context.Teachers
        //    .Where(t => t.Id == id)
        //    .Include(t => t.TeacherDetails)
        //    .Include(t => t.TeacherContactInfo)
        //    .Include(t => t.TeacherSocialMedia)
        //    .Include(t => t.TeacherSkills)
        //    .Include(t => t.Faculty)
        //    .Include(t => t.Position)
        //    .FirstOrDefaultAsync();
        //TeacherDetailsVM teacherDetailsVM = new TeacherDetailsVM()
        //{
        //    Teacher = teacher,
        //    TeacherSkills = teacherSkills
        //};
        //        return teacherDetailsVM;
        public async Task<Course> GetCourseById(int id)
        {
            try
            {
                Course course = await _context.Courses
                    .Where(c => c.Id == id)
                    .Include(c => c.Assestment)
                    .Include(c => c.Category)
                    .Include(c => c.Language)
                    .Include(c => c.CourseImages)
                    .Include(c => c.CourseDetails)
                    .FirstOrDefaultAsync();
                return course;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
