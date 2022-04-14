using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class SubscribeVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
