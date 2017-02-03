using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Tras.Core.Domain.Common;
using Tras.Data;
using Tras.Data.Infrastructure;
using Tras.Services.Configuration;
using Tras.Services.Employee;
using Tras.Services.Process;
using Tras.Services.Ration;
using Tras.Services.Residence;
using Tras.Services.Distribution;

namespace Tras.Web
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //Object context
            builder.Register<IDbContext>(c => new TrasObjectContext()).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Cache manager
            builder.RegisterType<CacheManager>().As<ICacheManager>().InstancePerLifetimeScope();

            //Services
            builder.RegisterType<LookupService>().As<ILookupService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitService>().As<IUnitService>().InstancePerLifetimeScope();
            builder.RegisterType<RankService>().As<IRankService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<FamilyInfoService>().As<IFamilyInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorService>().As<IDirectorService>().InstancePerLifetimeScope();
            builder.RegisterType<RationHeadService>().As<IRationHeadService>().InstancePerLifetimeScope();
            builder.RegisterType<RationSubHeadService>().As<IRationSubHeadService>().InstancePerLifetimeScope();
            builder.RegisterType<RationItemCategoryService>().As<IRationItemCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<RationItemService>().As<IRationItemService>().InstancePerLifetimeScope();
            builder.RegisterType<PackageService>().As<IPackageService>().InstancePerLifetimeScope();
            builder.RegisterType<MessService>().As<IMessService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<PackageItemService>().As<IPackageItemService>().InstancePerLifetimeScope();
            builder.RegisterType<DispersionRecordService>().As<IDispersionRecordService>().InstancePerLifetimeScope();
            builder.RegisterType<DispersionItemRecordService>().As<IDispersionItemRecordService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonPackageService>().As<IPersonPackageService>().InstancePerLifetimeScope();
            builder.RegisterType<DispersionService>().As<IDispersionService>().InstancePerLifetimeScope();

            // 
            builder.RegisterType<StationService>().As<IStationService>().InstancePerLifetimeScope();
            builder.RegisterType<RationDemandService>().As<IRationDemandService>().InstancePerLifetimeScope();
            // Register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register Filter Provider
            builder.RegisterFilterProvider();

            //Register modules
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            #region Model binder providers - excluded - not sure if need
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();
            #endregion

            /*
             The MVC Integration includes an Autofac module that will add HTTP request 
             lifetime scoped registrations for the HTTP abstraction classes. The 
             following abstract classes are included: 
            -- HttpContextBase 
            -- HttpRequestBase 
            -- HttpResponseBase 
            -- HttpServerUtilityBase 
            -- HttpSessionStateBase 
            -- HttpApplicationStateBase 
            -- HttpBrowserCapabilitiesBase 
            -- HttpCachePolicyBase 
            -- VirtualPathProvider 

            To use these abstractions add the AutofacWebTypesModule to the container 
            using the standard RegisterModule method. 
            */
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}