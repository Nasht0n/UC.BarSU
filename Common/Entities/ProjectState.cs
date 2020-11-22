using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class ProjectState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<ScienceProject> Projects { get; set; }
    }
}