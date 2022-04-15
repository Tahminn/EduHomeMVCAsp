using Domain.Entities.Common;
using System.Collections.Generic;

namespace Domain.Entities.CourseModel
{
    public class Course : BaseEntity
    {
        public string Description { get; set; }
        public int CourseLanguageId { get; set; }
        public CourseLanguage Language { get; set; }
        public int CourseAssestmentId { get; set; }
        public CourseAssestment Assestment { get; set; }
        public int CategoryId { get; set; }
        public CourseCategory Category { get; set; }
        public CourseDetails CourseDetails { get; set; }
        public CourseFeatures CourseFeatures { get; set; }
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
        public int MyProperty { get; set; }
        public ICollection<CourseImages> CourseImages { get; set; }
    }
}
