using Common.Entities;
using System.Collections.Generic;

namespace Web.ViewModels.BY
{
    public class BYDetailsViewModel
    {
        public AppUser User { get; set; }
        public BankYouth BankYouth { get; set; }
        public List<BankYouthAward> Awards { get; set; }
        public List<BankYouthDocumentation> Documentations { get; set; }
        public List<BankYouthPublication> Publications { get; set; }
    }
}