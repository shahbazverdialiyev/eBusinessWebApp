using System.ComponentModel.DataAnnotations;

namespace eBusinessWebApp.ViewModels.AppUserVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "bosh qala bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
