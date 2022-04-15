using Domain;
using Domain.Entities.CourseModel;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Utilities.Helpers;
using Service.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.BaseModels
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paginate<Course>> GetCourses(int take, int page)
        {
            try
            {
                List<int> CourseIds = await _context.Courses.OrderByDescending(e => e.Id).Select(e => e.Id).ToListAsync();
                int after = CourseIds.ElementAtOrDefault(take * (page - 1));
                int count = CourseIds.Count();
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
