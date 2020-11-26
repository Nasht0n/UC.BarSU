using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ImplementationStudentAct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Scope { get; set; }
        [Required]        
        public string Department { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        [MaxLength(255)]
        public string Author { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string PracticalTasks { get; set; }
        [Required]
        public string EconomicEfficiency { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProtocolDate { get; set; }
        [Required]
        public string ProtocolNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public virtual ICollection<ImplementationStudentActComission> Comissions { get; set; }
        public virtual ICollection<ImplementationStudentActLifeCycle> LifeCycles { get; set; }
    }
}
