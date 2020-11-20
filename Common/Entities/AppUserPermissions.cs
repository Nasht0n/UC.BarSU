using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class AppUserPermissions
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        [ForeignKey("PermissionId")]
        public AppPermission Permsission { get; set; }
    }
}
