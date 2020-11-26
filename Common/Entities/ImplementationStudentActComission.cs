using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ImplementationStudentActComission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ActId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Post { get; set; }

        [ForeignKey("ActId")]
        public ImplementationStudentAct Act { get; set; }
    }
}
