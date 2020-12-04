using Common.Entities;
using System.Collections.Generic;

namespace Web.ViewModels.IA.Research
{
    public class IAResearchViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        
        public string ImplementingResult { get; set; }
        public string Process { get; set; }
        public string Characteristic { get; set; }
        public string ImplementationForm { get; set; }
        public string UnitUsing { get; set; }
        public string FeasibilityOfIntroducing { get; set; }
        public string HeadUnit { get; set; }
        public AppUser User { get; set; }

        public IList<ImplementationResearchActEmployees> Employees { get; set; }
        public IList<ImplementationResearchActAuthors> Authors { get; set; }
    }
}