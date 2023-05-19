using System.ComponentModel.DataAnnotations;

namespace eBusinessWebApp.ViewModels.AppUserVM
{
    public class RegisterVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage="bosh qala bilmez"),MaxLength(30,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Name { get; set; }
        [Required(ErrorMessage="bosh qala bilmez"),MaxLength(30,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Surname { get; set; }
        [Required(ErrorMessage="bosh qala bilmez"),MaxLength(30,ErrorMessage ="maksimum uzunluq 16 ola biler"),EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage="bosh qala bilmez"),MaxLength(30,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Username { get; set; }
        [Required(ErrorMessage="bosh qala bilmez"),MaxLength(30,ErrorMessage ="maksimum uzunluq 16 ola biler"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "bosh qala bilmez"), MaxLength(30, ErrorMessage = "maksimum uzunluq 16 ola biler"), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
