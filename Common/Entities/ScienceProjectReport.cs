using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ScienceProjectReport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StageId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Filename { get; set; }
        [Required]
        [MaxLength(255)]
        public string Path { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }

        [ForeignKey("StageId")]
        public Stage Stage { get; set; }
    }
}
