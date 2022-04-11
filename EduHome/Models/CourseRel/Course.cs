using EduHome.Models.APrimary;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models.CourseRel
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
        public ICollection<CourseImages> CourseImages { get; set; }
    }
}
