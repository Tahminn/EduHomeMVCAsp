using Domain.Entities.CourseModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities.Common
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActivated { get; set; }
        public ICollection<Course> MyProperty { get; set; }
    }
}
