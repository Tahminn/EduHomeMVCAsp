using EduHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachers(int takeProducts, int skipProduct);
    }
}
