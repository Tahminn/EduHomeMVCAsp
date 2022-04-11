using EduHome.Data;
using EduHome.Models.CourseRel;
using EduHome.Services.Interfaces;
using EduHome.Utilities.Helpers;
using EduHome.Utilities.Pagination;
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

        public async Task<Paginate<Course>> GetCourses(int take, int after, int count, int page)
        {
            try
            {
                List<Course> courses = await _context.Courses
                    .Where(c => c.Id < after && !c.IsDeleted)
                    .Include(c => c.Assestment)
                    .Include(c => c.Category)
                    .Include(c => c.Language)
                    .Include(c => c.CourseImages)
                    .Include(c => c.CourseFeatures)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                if (take > 0) courses = courses.Take(take).ToList();
                int totalPage = Helper.GetPageCount(count, take);
                Paginate<Course> paginatedCourse = new Paginate<Course>(courses, page, totalPage);
                return paginatedCourse;
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                    .Include(c => c.CourseFeatures)
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
