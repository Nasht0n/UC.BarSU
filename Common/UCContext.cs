﻿using Common.Entities;
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

        #region Implementation Student Acts

        public virtual DbSet<ImplementationStudentAct> StudentActs { get; set; }
        public virtual DbSet<ImplementationStudentActComission> StudentActComissions { get; set; }
        public virtual DbSet<ImplementationStudentActLifeCycle> StudentActLifeCycles { get; set; }

        #endregion

        #region Implementation Research Acts
        public virtual DbSet<ImplementationResearchAct> ResearchActs { get; set; }
        public virtual DbSet<ImplementationResearchActAuthors> ResearchActAuthors { get; set; }
        public virtual DbSet<ImplementationResearchActEmployees> ResearchActEmployees { get; set; }
        public virtual DbSet<ImplementationResearchActLifeCycle> ResearchActLifeCycles { get; set; }
        #endregion

        #region BankYouth
        public virtual DbSet<BankYouth> BankYouths { get; set; }
        public virtual DbSet<BankYouthAward> Awards { get; set; }
        public virtual DbSet<BankYouthDocumentation> Documentations { get; set; }
        public virtual DbSet<BankYouthPublication> Publications { get; set; }
        #endregion

        public virtual DbSet<PaidServices> PaidServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserPermissions>().HasKey(c => new { c.UserId, c.PermissionId });
        }
    }
}
