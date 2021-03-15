using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class PaidServices
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [MaxLength(255)]
        public string ServiceName { get; set; }
        [Required]
        [MaxLength(255)]
        public string PeriodOfExecution { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Post { get; set; }
        [Required]
        [MaxLength(255)]
        public string Degree { get; set; }
        [Required]
        [MaxLength(255)]
        public string Status { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
