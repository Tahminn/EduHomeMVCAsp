using EduHome.Models.BlogRel;
using EduHome.Models.CourseRel;
using EduHome.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.ViewModels.SidebarVMs
{
    public class SidebarVM
    {
        public List<CourseCategory> Categories { get; set; }
        public Paginate<Blog> Blogs { get; set; }
    }
}
