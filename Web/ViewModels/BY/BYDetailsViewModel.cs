using Common.Entities;
using System.Collections.Generic;

namespace Web.ViewModels.BY
{
    public class BYDetailsViewModel
    {
        public AppUser User { get; set; }
        public BankYouth BankYouth { get; set; }
        public BankYouthAwardViewModel AwardModel { get; set; }
        public List<BankYouthAward> Awards { get; set; }
        public BankYouthDocumentationViewModel DocumentationModel { get; set; }
        public List<BankYouthDocumentation> Documentations { get; set; }
        public BankYouthPublicationViewModel PublicationModel { get; set; }
        public List<BankYouthPublication> Publications { get; set; }
    }
}