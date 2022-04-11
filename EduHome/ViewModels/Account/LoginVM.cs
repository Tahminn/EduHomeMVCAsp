using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LessonMigration.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
