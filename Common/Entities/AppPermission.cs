using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class AppPermission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }        
        [Required]
        public string Description { get; set; }
    }
}
