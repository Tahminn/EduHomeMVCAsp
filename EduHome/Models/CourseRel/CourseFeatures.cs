using EduHome.Models.APrimary;
using System;

namespace EduHome.Models.CourseRel
{
    public class CourseFeatures : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public int Capacity { get; set; }
        public decimal Fee { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
