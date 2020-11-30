using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.IA.Students
{
    public class IAStudentViewModel
    {
        [Display(Name ="Идентификатор акта внедрения")]
        public int Id { get; set; }

        [Display(Name = "Сфера применения результатов исследования")]
        [Required(ErrorMessage = "Введите сферу применения результатов исследования")]
        [MaxLength(255, ErrorMessage = "Наименование сферы применения не должно превышать 255 символов")]
        public string Scope { get; set; }

        [Display(Name = "Наименование структурного подразделения")]
        [Required(ErrorMessage = "Введите наименование структурного подразделения")]
        [DataType(DataType.MultilineText)]
        public string Department { get; set; }

        [Display(Name = "Результаты внедрения исследования")]
        [Required(ErrorMessage = "Введите результаты внедрения исследования")]
        [DataType(DataType.MultilineText)]
        public string Result { get; set; }

        [Display(Name = "ФИО автора работы")]
        [Required(ErrorMessage = "Введите полное ФИО автора работы")]
        [MaxLength(255, ErrorMessage = "Полное ФИО автора работы не должно превышать 255 символов")]
        public string Author { get; set; }

        [Display(Name = "Наименование работы")]
        [Required(ErrorMessage = "Введите наименование работы")]
        public string ProjectName { get; set; }

        [Display(Name = "Практические задачи")]
        [Required(ErrorMessage = "Укажите решаемые практические задачи")]
        [DataType(DataType.MultilineText)]
        public string PracticalTasks { get; set; }

        [Display(Name = "Экономическая эффективность")]
        [Required(ErrorMessage = "Укажите экономический эффект от использования результатов работы")]
        [DataType(DataType.MultilineText)]
        public string EconomicEfficiency { get; set; }

        [Display(Name = "Дата протокола")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату протокола заседания")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = "Номер протокола")]
        [Required(ErrorMessage = "Укажите номер протокола заседания")]
        public string ProtocolNumber { get; set; }

        [Display(Name = "Дата регистрации акта")]
        [Required(ErrorMessage = "Выберите дату регистрации акта")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }


    }
}