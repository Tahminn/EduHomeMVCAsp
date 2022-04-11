using EduHome.Models.BlogRel;
using EduHome.Utilities.Pagination;
using System.Threading.Tasks;

namespace EduHome.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Paginate<Blog>> GetBlogs(int take, int after, int page);
        Task<Blog> GetBlogById(int id);
    }
}
