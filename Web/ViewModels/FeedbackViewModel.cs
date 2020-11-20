using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Введите ваше имя")]
        [MaxLength(255, ErrorMessage = "Длина ФИО не должна превышать 255 символов")]
        [DataType(DataType.Text)]
        [Display(Name = "Введите ваше имя")]
        public string Name { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Длина адреса электронной почты не должна превышать 255 символов")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Введите электронную почту")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(150, ErrorMessage = "Длина заголовка отзыва не более 150 символов")]
        [Display(Name = "Введите тему сообщения")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Введите сообщение")]
        public string Message { get; set; }
    }
}