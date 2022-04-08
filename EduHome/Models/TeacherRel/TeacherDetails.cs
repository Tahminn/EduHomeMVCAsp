using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models.TeacherRel
{
    public class TeacherDetails : BaseEntity
    {
        public string About { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public string Hobbies { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
