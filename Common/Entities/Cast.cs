using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string Degree { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Post { get; set; }
        [Required]
        public bool IsManager { get; set; }

        public ScienceProject Project { get; set; }
    }
}
