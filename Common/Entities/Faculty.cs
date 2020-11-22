using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(25)]
        public string Shortname { get; set; }

        public virtual IList<Department> Departments { get; set; }
    }
}