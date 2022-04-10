using EduHome.Models.APrimary;

namespace EduHome.Models.CourseRel
{
    public class CourseDetails : BaseEntity
    {
        public string About { get; set; }
        public string Application { get; set; }
        public string Certification { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
