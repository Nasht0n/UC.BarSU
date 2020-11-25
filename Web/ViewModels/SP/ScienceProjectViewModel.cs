using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels
{
    public class ScienceProjectViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }

        [Required]
        [Display(Name = "Факультет")]
        public int SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public int SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }        

        [Required(ErrorMessage = "Введите наименование научного проекта")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        [Display(Name = "Наименование научного проекта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите наименование программы научного проекта")]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 символов")]
        [Display(Name = "Наименование программы научного проекта")]
        public string Program { get; set; }

        [Required(ErrorMessage = "Введите номер приказа")]
        [MaxLength(25, ErrorMessage = "Длина не должна превышать 25 символов")]
        [Display(Name = "Номер приказа")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату приказа")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата приказа")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Введите номер государственной регистрации проекта")]
        [MaxLength(25, ErrorMessage = "Длина не должна превышать 25 символов")]
        [Display(Name = "Номер гос. регистрации")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату государственной регистрации")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата регистрации")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Введите стоимость проекта")]
        [Display(Name = "Стоимость научного проекта")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите дату начала работы над проектом")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала работы над проектом")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Укажите дату окончания работы над проектом")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата окончания работы над проектом")]
        public DateTime EndDate { get; set; }

        public List<Cast> Casts { get; set; } = new List<Cast>();
    }
}