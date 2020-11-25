using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModels
{
    public class SPDetailsViewModel
    {
        [Required(ErrorMessage = "Укажите тип этапа выполнения научного проекта")]
        [Display(Name = "Тип этапа")]
        public int SelectedStageType { get; set; }
        public IEnumerable<SelectListItem> StageTypes { get; set; }

        public AppUser User { get; set; }
        public ScienceProject Project { get; set; }
        public List<ScienceProjectReport> Reports{ get; set; }
        public Stage Stage { get; set; }
        public List<Stage> Stages { get; set; }
        [Display(Name = "Путь к файлам")]
        public ScienceProjectReport Report { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
    }
}