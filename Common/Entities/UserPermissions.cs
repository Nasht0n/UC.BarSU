using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    [Table("AppUserPermissions")]
    public class UserPermissions
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("PermissionId")]
        public Permsission Permsission { get; set; }
    }
}
