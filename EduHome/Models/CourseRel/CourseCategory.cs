using EduHome.Models.APrimary;
using System.Collections.Generic;

namespace EduHome.Models.CourseRel
{
    public class CourseCategory : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<CourseCategory> Children { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
