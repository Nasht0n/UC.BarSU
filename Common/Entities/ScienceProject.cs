using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class ScienceProject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Program { get; set; }
        [Required]
        [MaxLength(25)]
        public string OrderNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]
        [MaxLength(25)]
        public string RegistrationNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        [ForeignKey("StateId")]
        public ProjectState ProjectState { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
    }
}