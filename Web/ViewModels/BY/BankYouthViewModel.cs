using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.BY
{
    public class BankYouthViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Введите фамилию студента")]
        [Display(Name = "Фамилия студента")]
        [MaxLength(255)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите имя студента")]
        [Display(Name = "Имя студента")]
        [MaxLength(255)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Введите отчество студента")]
        [Display(Name = "Отчество студента")]
        [MaxLength(255)]
        public string Patronymic { get; set; }
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Укажите дату рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirthday { get; set; }
        [Required(ErrorMessage = "Введите номер мобильного телефона")]
        [Display(Name = "Мобильный телефон")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите наименование области проживания")]
        [Display(Name = "Область")]
        [MaxLength(255)]
        public string Area { get; set; }
        [Required(ErrorMessage = "Введите наименование района проживания")]
        [Display(Name = "Район")]
        [MaxLength(255)]
        public string District { get; set; }
        [Required(ErrorMessage = "Введите наименование населенного пункта")]
        [Display(Name = "Наименование населенного пункта")]
        [MaxLength(255)]
        public string Settlement { get; set; }
        [Required(ErrorMessage = "Укажите год поступления в университет")]
        [Display(Name = "Год поступления в университет")]
        public int YearOfAddmission { get; set; }
        [Required(ErrorMessage = "Введите специальность студента")]
        [Display(Name = "Специальность")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string Speciality { get; set; }
        [Required(ErrorMessage = "Укажите квалификацию")]
        [Display(Name = "Квалификация")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Укажите год включения в банк данных")]
        [Display(Name = "Год включения в банк данных")]
        public int YearOfInclusion { get; set; }
        [Required(ErrorMessage = "Укажите заслуги студента")]
        [Display(Name = "Заслуги студента")]
        [DataType(DataType.MultilineText)]
        public string Merit { get; set; }
        [Required(ErrorMessage = "Укажите средний балл")]
        [Display(Name = "Средний балл")]
        public double AverageBall { get; set; }
        [Required]
        [Display(Name = "Баллы только '9' и '10' (или только одна отметка '8' по непрофильной учебной дисциплине)")]
        public bool IsExcellentStudent { get; set; }
        [Required(ErrorMessage = "Заполните поле поощрения студента")]
        [Display(Name = "Поощрения студента")]
        [DataType(DataType.MultilineText)]
        public string Incentives { get; set; }
        [Required(ErrorMessage = "Укажите номер протокола")]
        [Display(Name = "Номер протокола")]
        [MaxLength(150)]
        public string ProtocolNumber { get; set; }
        [Required(ErrorMessage = "Укажите дату протокола")]
        [Display(Name = "Дата протокола")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProtocolDate { get; set; }
        [Required(ErrorMessage = "Укажите ФИО руководителя")]
        [Display(Name = "ФИО")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Укажите должность")]
        [Display(Name = "Должность")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string Post { get; set; }
        [Required(ErrorMessage = "Укажите ученое звание")]
        [Display(Name = "Ученое звание")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string AcademicStatus { get; set; }
        [Required(ErrorMessage = "Укажите ученую степень руководителя")]
        [Display(Name = "Ученая степень")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        public string AcademicDegree { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public SelectList ExcellentStudentList { get; set; }
    }
}