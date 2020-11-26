using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ImplementationStudentActLifeCycle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ActId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(255)]
        public string Message { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        [ForeignKey("ActId")]
        public ImplementationStudentAct Act { get; set; }
    }
}
