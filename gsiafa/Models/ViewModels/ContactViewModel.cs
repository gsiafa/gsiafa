using System.ComponentModel.DataAnnotations;

namespace gsiafa.Models
{
    public class ContactViewModel
    {    

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; } =string.Empty;
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please write your message.")]
        public string Message { get; set; } = string.Empty;
    }
}
