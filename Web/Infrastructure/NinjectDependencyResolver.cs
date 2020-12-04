using Ninject;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            #region App Repository
            kernel.Bind<IFeedbackRepository>().To<FeedbackRepository>();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();
            kernel.Bind<IUserPermissionsRepository>().To<UserPermissionRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            #endregion

            #region SP Repository
            kernel.Bind<ICastRepository>().To<CastRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<IFacultyRepository>().To<FacultyRepository>();
            kernel.Bind<IProjectStateRepository>().To<ProjectStateRepository>();
            kernel.Bind<IScienceProjectReportRepository>().To<ScienceProjectReportRepository>();
            kernel.Bind<IScienceProjectRepository>().To<ScienceProjectRepository>();
            kernel.Bind<IStageRepository>().To<StageRepository>();
            kernel.Bind<IStageTypeRepository>().To<StageTypeRepository>();
            #endregion

            #region IAS Repository
            kernel.Bind<IImplementationStudentActComissionRepository>().To<ImplementationStudentActComissionRepository>();
            kernel.Bind<IImplementationStudentActLifeCycleRepository>().To<ImplementationStudentActLifeCycleRepository>();
            kernel.Bind<IImplementationStudentActRepository>().To<ImplementationStudentActRepository>();
            #endregion

            #region IAR Repository
            kernel.Bind<IImplementationResearchActAuthorsRepository>().To<ImplementationResearchActAuthorsRepository>();
            kernel.Bind<IImplementationResearchActEmployeesRepository>().To<ImplementationResearchActEmployeesRepository>();
            kernel.Bind<IImplementationResearchActLifeCycleRepository>().To<ImplementationResearchActLifeCycleRepository>();
            kernel.Bind<IImplementationResearchActRepository>().To<ImplementationResearchActRepository>();
            #endregion
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}