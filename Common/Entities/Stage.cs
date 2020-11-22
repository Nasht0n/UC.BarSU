using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class Stage
    {
        public int ProjectId { get; set; }
        public int StageTypeId { get; set; }

        [ForeignKey("ProjectId")]
        public ScienceProject Project { get; set; }
        [ForeignKey("StageTypeId")]
        public StageType StageType { get; set; }
    }
}