using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class BankYouth
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        #region Идентификация студента
        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Patronymic { get; set; }
        [Required]
        public DateTime DateOfBirthday { get; set; }
        [Required]
        [MaxLength(150)]
        public string MobilePhone { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Area { get; set; }
        [Required]
        [MaxLength(255)]
        public string District { get; set; }
        [Required]
        [MaxLength(255)]
        public string Settlement { get; set; }
        [Required]
        public int YearOfAddmission { get; set; }
        [Required]
        [MaxLength(255)]
        public string Speciality { get; set; }
        [Required]
        [MaxLength(255)]
        public string Qualification { get; set; }
        #endregion

        #region Основание для включения в банк данных
        [Required]
        public int YearOfInclusion { get; set; }
        [Required]
        public string Merit { get; set; }
        [Required]
        public double AverageBall { get; set; }
        [Required]
        public bool IsExcellentStudent { get; set; }
        [Required]
        public string Incentives { get; set; }
        [Required]
        [MaxLength(150)]
        public string ProtocolNumber { get; set; }
        [Required]
        public DateTime ProtocolDate { get; set; }
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(255)]
        public string Post { get; set; }
        [Required]
        [MaxLength(255)]
        public string AcademicStatus { get; set; }
        [Required]
        [MaxLength(255)]
        public string AcademicDegree { get; set; }
        #endregion

        public List<BankYouthAward> Awards { get; set; }
        public List<BankYouthPublication> Publications { get; set; }
        public List<BankYouthDocumentation> Documentations { get; set; }
    }
}
