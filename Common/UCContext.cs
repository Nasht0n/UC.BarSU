using Common.Entities;
using System.Data.Entity;

namespace Common
{
    public class UCContext : DbContext
    {
        public UCContext() : base("UCContext")
        {

        }
        #region AppTables
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AppPermission> Permissions { get; set; }
        public virtual DbSet<AppFeedback> Feedbacks { get; set; }
        public virtual DbSet<AppUserPermissions> UserPermissions { get; set; }
        #endregion


        #region ScienceProjects
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<ProjectState> ProjectStates { get; set; }
        public virtual DbSet<ScienceProject> ScienceProjects { get; set; }
        public virtual DbSet<ScienceProjectReport> ScienceProjectReports { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<StageType> StageTypes { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserPermissions>().HasKey(c => new { c.UserId, c.PermissionId });
        }
    }
}
