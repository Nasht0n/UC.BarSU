using System;
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
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string Settlement { get; set; }
        public int YearOfAddmission { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }
        #endregion

        #region Основание для включения в банк данных
        public int YearOfInclusion { get; set; }
        public string Merit { get; set; }
        public double AverageBall { get; set; }
        public bool IsExcellentStudent { get; set; }
        public string Incentives { get; set; }
        public string ProtocolNumber { get; set; }
        public DateTime ProtocolDate { get; set; }
        public string Fullname { get; set; }
        public string Post { get; set; }
        public string AcademicStatus { get; set; }
        public string AcademicDegree { get; set; }
        #endregion
    }
}
