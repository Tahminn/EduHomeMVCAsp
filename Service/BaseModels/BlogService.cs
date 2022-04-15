using Domain;
using Domain.Entities.BlogModel;
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
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paginate<Blog>> GetBlogs(int take, int page)
        {
            try
            {
                List<int> BlogIds = await _context.Blogs.OrderByDescending(e => e.Id).Select(e => e.Id).ToListAsync();
                int after = BlogIds.ElementAtOrDefault(take * (page - 1));
                int count = BlogIds.Count();
                List<Blog> Blogs = await _context.Blogs
                      .Where(b => b.Id <= after && !b.IsDeleted)
                      .Include(b => b.BlogImages)
                      .OrderByDescending(b => b.Id)
                      .ToListAsync();
                if (take > 0) Blogs = Blogs.Take(take).ToList();
                int totalPage = Helper.GetPageCount(count, take);
                Paginate<Blog> paginatedBlog = new Paginate<Blog>(Blogs, page, totalPage);
                return paginatedBlog;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Blog> GetBlogById(int id)
        {
            try
            {
                Blog blog = await _context.Blogs
                    .Where(b => b.Id == id)
                    .Include(b => b.BlogImages)
                    .FirstOrDefaultAsync();
                return blog;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
