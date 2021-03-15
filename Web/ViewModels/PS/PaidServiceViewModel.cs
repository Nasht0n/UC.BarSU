using Common.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.PS
{
    public class PaidServiceViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите наименование заказчика")]
        [Display(Name = "Наименование заказчика")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите местоположение заказчика")]
        [Display(Name = "Местоположение заказчика")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите номер договора")]
        [Display(Name = "Номер договора")]
        [MaxLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату договора")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата договора")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название работы (услуги) (предмет договора)")]
        [Display(Name = "Название услуги")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string ServiceName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите срок выполнения работы")]
        [Display(Name = "Срок выполения")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string PeriodOfExecution { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите общую стоимость услуг")]
        [Display(Name = "Общая стоимость услуг")]
        public decimal TotalCost { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите ФИО исполнителя")]
        [Display(Name = "ФИО исполнителя")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Fullname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите должность исполнителя")]
        [Display(Name = "Должность")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Post { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите учёную степень исполнителя")]
        [Display(Name = "Учёная степень")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Degree { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите учёное звание исполнителя")]
        [Display(Name = "Учёное звание")]
        [MaxLength(255, ErrorMessage = "Длина поля не должна превышать 255 символов")]
        public string Status { get; set; }
    }
}