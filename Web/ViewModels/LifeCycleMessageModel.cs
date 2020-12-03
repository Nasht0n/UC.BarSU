using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class LifeCycleMessageModel
    {
        public int ActId { get; set; }

        [Required(ErrorMessage = "Введите тему сообщения")]
        [Display(Name = "Тема")]
        [MaxLength(255,ErrorMessage = "Поле не должно содержать более 255 символов")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Сообщение")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}