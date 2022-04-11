//using EduHome.Data;
//using EduHome.Models.BlogRel;
//using EduHome.Services.Interfaces;
//using EduHome.Utilities.Helpers;
//using EduHome.Utilities.Pagination;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EduHome.Services
//{
//    public class BlogService : IBlogService
//    {
//        private readonly AppDbContext _context;
//        public BlogService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Paginate<Blog>> GetBlogs(int take, int after, int page)
//        {
//            try
//            {
//                after = _context.Blogs.ElementAtOrDefault((page - 1) * take).Id;
//                List<Blog> blogs;
//                List<Blog> blogsAll;
//                if (after is 0)
//                {
//                    blogsAll = await _context.Blogs
//                    .Where(b => !b.IsDeleted)
//                    .Include(b => b.BlogImages)
//                    .OrderByDescending(t => t.Id)
//                    .ToListAsync();
//                }
//                else
//                {
//                    blogsAll = await _context.Blogs
//                    .Where(b => b.Id < after && !b.IsDeleted)
//                    .Include(b => b.BlogImages)
//                    .OrderByDescending(t => t.Id)
//                    .ToListAsync();
//                }
//                var count = blogsAll.Count();
//                blogs = blogsAll.Take(take).ToList();
//                int totalPage = Helper.GetPageCount(count, take);
//                Paginate<Blog> paginatedCourse = new Paginate<Blog>(blogs, page, totalPage);
//                return paginatedCourse;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<Blog> GetBlogById(int id)
//        {
//            try
//            {
//                Blog blog = await _context.Blogs
//                    .Where(b => b.Id == id)
//                    .Include(b => b.BlogImages)
//                    .FirstOrDefaultAsync();
//                return blog;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
