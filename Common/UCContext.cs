using Common.Entities;
using System.Data.Entity;

namespace Common
{
    public class UCContext:DbContext
    {
        public UCContext():base("UCContext")
        {

        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AppPermission> Permissions { get; set; }
        public virtual DbSet<AppFeedback> Feedbacks { get; set; }
        public virtual DbSet<AppUserPermissions> UserPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserPermissions>().HasKey(c=> new { c.UserId, c.PermissionId });
        }
    }
}
