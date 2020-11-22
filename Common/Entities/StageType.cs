using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class StageType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}