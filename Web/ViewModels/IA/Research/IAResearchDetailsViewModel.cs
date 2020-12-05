using Common.Entities;
using System.Collections.Generic;

namespace Web.ViewModels.IA.Research
{
    public class IAResearchDetailsViewModel
    {
        public AppUser User { get; set; }
        public ImplementationResearchAct Act { get; set; }
        public List<ImplementationResearchActLifeCycle> LifeCycles { get; set; }
        public List<ImplementationResearchActEmployees> Employees { get; set; }
        public List<ImplementationResearchActAuthors> Authors { get; set; }
        public LifeCycleMessageModel MessageModel { get; set; }
    }
}