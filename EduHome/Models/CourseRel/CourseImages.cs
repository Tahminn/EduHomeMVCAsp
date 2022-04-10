using EduHome.Models.APrimary;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models.CourseRel
{
    public class CourseImages : BaseEntity
    {
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
