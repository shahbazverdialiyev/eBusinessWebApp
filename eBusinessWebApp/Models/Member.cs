using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBusinessWebApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="bosh qala bilmez"),MaxLength(16,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Name { get; set; }
        [Required(ErrorMessage ="bosh qala bilmez"),MaxLength(16,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="bosh qala bilmez"),MaxLength(16,ErrorMessage ="maksimum uzunluq 16 ola biler")]
        public string Position { get; set; }
        public int? ImageId { get; set; }
        public Image? Image { get; set; }
        [NotMapped]
        public IFormFile formImage { get; set; }
    }
}
