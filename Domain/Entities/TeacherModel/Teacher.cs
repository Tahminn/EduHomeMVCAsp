using Domain.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TeacherModel
{
    public class Teacher : BaseEntity
    {
        [Required(ErrorMessage = "The Name field should not be empty.")]
        [StringLength(20, ErrorMessage = "The Name field length should not be over 20 characters.")]
        public string Name { get; set; }
        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public TeacherDetails TeacherDetails { get; set; }
        public TeacherContactInfo TeacherContactInfo { get; set; }
        public TeacherSocialMedia TeacherSocialMedia { get; set; }
        public ICollection<TeacherSkill> TeacherSkills { get; set; }
    }
}
