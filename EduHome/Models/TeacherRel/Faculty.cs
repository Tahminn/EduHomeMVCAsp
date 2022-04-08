using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models.TeacherRel
{
    public class Faculty : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
