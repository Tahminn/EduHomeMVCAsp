using System.Collections.Generic;

namespace EduHome.Models.TeacherRel
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TeacherSkill> TeacherSkills { get; set; }
    }
}
