using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class BankYouthPublication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BankYouthId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Filename { get; set; }
        [Required]
        public string Path { get; set; }
        [ForeignKey("BankYouthId")]
        public BankYouth BankYouth { get; set; }
    }
}
