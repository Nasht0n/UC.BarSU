using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Web.ViewModels.BY
{
    public class BankYouthAwardViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Дата")]
        public string Date { get; set; }
        [Required]
        public string Filename { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        [Display(Name = "Путь к файлу")]
        public HttpPostedFileBase[] AwardFiles { get; set; }
    }
}