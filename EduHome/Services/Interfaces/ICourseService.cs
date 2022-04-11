using EduHome.Models.CourseRel;
using EduHome.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Paginate<Course>> GetCourses(int take, int after, int count, int page);
        Task<Course> GetCourseById(int id);
    }
}
