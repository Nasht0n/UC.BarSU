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
        public string ScopeOfApplication { get; set; }

        [Display(Name = "Количество человек в комиссии")]
        [Required(ErrorMessage = "Укажите количество человек в комиссии")]
        [Range(1,20,ErrorMessage = "Указанное количество человек должно быть в пределах от 1 до 20 человек")]
        public int NumberOfPeople { get; set; }

        [Display(Name = "Наименование структурного подразделения")]
        [Required(ErrorMessage = "Введите наименование структурного подразделения")]
        public string Department { get; set; }

        [Display(Name = "Результаты внедрения исследования")]
        [Required(ErrorMessage = "Введите результаты внедрения исследования")]
        public string Result { get; set; }

        [Display(Name = "ФИО автора работы")]
        [Required(ErrorMessage = "Введите полное ФИО автора работы")]
        public string Author { get; set; }

        [Display(Name = "Наименование работы")]
        [Required(ErrorMessage = "Введите наименование работы")]
        public string ProjectName { get; set; }

        [Display(Name = "Практические задачи")]
        public string PracticalTasks { get; set; }
        public string EconomicEfficiency { get; set; }
        public DateTime ProtocolDate { get; set; }
        public string ProtocolNumber { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<string> Commission { get; set; }
    }
}