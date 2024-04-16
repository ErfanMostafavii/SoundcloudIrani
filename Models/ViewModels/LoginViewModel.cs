using System.ComponentModel.DataAnnotations;

namespace soundcloud_.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }       
    }
}
