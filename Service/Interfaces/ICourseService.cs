using Domain.Entities.CourseModel;
using Service.Utilities.Pagination;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICourseService
    {
        Task<Paginate<Course>> GetCourses(int take, int page);
        Task<Course> GetCourseById(int id);
    }
}
