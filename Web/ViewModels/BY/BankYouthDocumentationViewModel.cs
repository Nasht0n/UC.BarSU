using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Web.ViewModels.BY
{
    public class BankYouthDocumentationViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Номер регистрации")]
        public string RegNumber { get; set; }
        [Required(ErrorMessage = "Укажите дату регистрации")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата регистрации")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        [Required]
        [Display(Name = "Путь к файлу")]
        public HttpPostedFileBase[] DocumentationFiles { get; set; }
    }
}