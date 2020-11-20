using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [MaxLength(25)]
        public string Password { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
    }
}
