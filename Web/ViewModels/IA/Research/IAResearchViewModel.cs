using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.IA.Research
{
    public class IAResearchViewModel
    {
        [Display(Name = "Идентификатор акта внедрения")]
        public int Id { get; set; }
        [Display(Name = "Идентификатор пользователя, который добавил акт в систему")]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "Введите наименование внедряемых результатов")]
        [Display(Name = "Наименование внедряемых результатов")]
        [DataType(DataType.MultilineText)]
        public string ImplementingResult { get; set; }
        [Required(ErrorMessage = "Укажите в рамках, какого процесса были получены результаты")]
        [Display(Name = "Процесс получения результатов исследовательской деятельности")]
        [DataType(DataType.MultilineText)]
        public string Process { get; set; }
        [Required(ErrorMessage = "Укажите характеристику объекта внедрения")]
        [Display(Name = "Харакетеристика объекта внедрения")]
        [DataType(DataType.MultilineText)]
        public string Characteristic { get; set; }
        [Required(ErrorMessage = "Укажите форму внедрения результатов")]
        [Display(Name = "Форма внедрения результатов")]
        [DataType(DataType.MultilineText)]
        public string ImplementationForm { get; set; }
        [Required(ErrorMessage = "Укажите форму внедрения результатов")]
        [Display(Name = "Кафедра (подразделение) использующая(ие) результаты")]
        [DataType(DataType.MultilineText)]
        public string UnitUsing { get; set; }
        [Required(ErrorMessage = "Укажите целесообразность внедрения")]
        [Display(Name = "Целесообразность внедрения")]
        [DataType(DataType.MultilineText)]
        public string FeasibilityOfIntroducing { get; set; }
        [Required(ErrorMessage = "Укажите ФИО руководителя структурного подразделения")]
        [Display(Name = "ФИО руководителя структурного подразделения")]
        public string HeadUnit { get; set; }
        public AppUser User { get; set; }
        [Required(ErrorMessage = "Укажите сотрудников, использующих результаты исследования")]
        [Display(Name = "Сотрудники, использующие результаты исследования")]
        public IList<ImplementationResearchActEmployees> Employees { get; set; }
        [Required(ErrorMessage = "Укажите авторов, результатов НИР")]
        [Display(Name = "Авторы результатов НИР")]
        public IList<ImplementationResearchActAuthors> Authors { get; set; }
    }
}