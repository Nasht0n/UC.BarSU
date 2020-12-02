using Common.Entities;
using System.Collections.Generic;

namespace Web.ViewModels.IA.Students
{
    public class IAStudentDetailsViewModel
    {
        public AppUser User { get; set; }
        public ImplementationStudentAct Act { get; set; }
        public List<ImplementationStudentActLifeCycle> LifeCycles { get; set; }
        public List<ImplementationStudentActComission> Comissions { get; set; }        
        public LifeCycleMessageModel MessageModel { get; set; }
    }
}