using EduHome.Models.CourseRel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses(int take, int after);
        Task<Course> GetCourseById(int id);
    }
}
