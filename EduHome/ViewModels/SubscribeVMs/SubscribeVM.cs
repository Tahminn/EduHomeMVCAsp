using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels.SubscribeVMs
{
    public class SubscribeVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
