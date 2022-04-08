namespace EduHome.Models.TeacherRel
{
    public class TeacherContactInfo : BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
