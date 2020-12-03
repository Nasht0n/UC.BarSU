using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ImplementationResearchAct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ImplementingResult { get; set; }
        [Required]
        public string Process { get; set; }
        [Required]
        public string Characteristic { get; set; }
        [Required]
        public string ImplementationForm { get; set; }
        [Required]
        public string UnitUsing { get; set; }
        [Required]
        public string FeasibilityOfIntroducing { get; set; }
        [Required]
        public string HeadUnit { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public IList<ImplementationResearchActEmployees> Employees { get; set; }
        public IList<ImplementationResearchActAuthors> Authors { get; set; }
        public IList<ImplementationResearchActLifeCycle> LifeCycles { get; set; }
    }
}
