using EduHome.Models;
using EduHome.Utilities.Pagination;
using EduHome.ViewModels.TeacherVMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Paginate<TeacherListVM>> GetTeachers(int take, int after, int count, int page);
        Task<TeacherDetailsVM> GetTeacherDetailsById(int id);
    }
}
