using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите логин пользователя")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль пользователя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}