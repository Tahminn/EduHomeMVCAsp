using Domain.Entities.BlogModel;
using Service.Utilities.Pagination;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBlogService
    {
        Task<Paginate<Blog>> GetBlogs(int take, int page);
        Task<Blog> GetBlogById(int id);
    }
}
