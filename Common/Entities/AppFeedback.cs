using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class AppFeedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]        
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
