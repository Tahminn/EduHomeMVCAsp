using EduHome.Models.APrimary;
using System.Collections.Generic;

namespace EduHome.Models.CourseRel
{
    public class CourseAssestment : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
