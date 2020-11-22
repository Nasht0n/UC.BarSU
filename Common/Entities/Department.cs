using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [MaxLength(25)]
        public string Shortname { get; set; }

        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }
    }
}
