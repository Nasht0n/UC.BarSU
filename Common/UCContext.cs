using Common.Entities;
using System.Data.Entity;

namespace Common
{
    public class UCContext:DbContext
    {
        public UCContext():base("UCContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permsission> Permsissions { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermissions>().HasKey(c=> new { c.UserId, c.PermissionId });
        }
    }
}
