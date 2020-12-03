using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ImplementationResearchActEmployees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ActId { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]        
        public string Post { get; set; }
        [ForeignKey("ActId")]
        public ImplementationResearchAct Act { get; set; }
    }
}
