using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class ImplementationResearchActAuthors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ActId { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Post { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicStatus { get; set; }

        public ImplementationResearchAct Act { get; set; }
    }
}
