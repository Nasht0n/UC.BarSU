using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    [Table("AppUser")]
    public class User
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
