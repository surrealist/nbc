using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using NBC.DataAccess.Bases;
using NBC.DataAccess.Contexts;
using NBC.DataAccess.Repositories;
using NBC.Models;
using NBC.Services;
using NBC.Services.Bases;

namespace NBC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            initAutoFac();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void initAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Repo>>>>Model
            builder.RegisterType<ActionTypeRepository>().As<IRepository<ActionType>>();
            builder.RegisterType<ActivityTypeRepository>().As<IRepository<ActivityType>>();
            builder.RegisterType<ActualWorkRepository>().As<IRepository<ActualWork>>();           
            builder.RegisterType<ApplicantRepository>().As<IRepository<Applicant>>();
            builder.RegisterType<CompanyRepository>().As<IRepository<Company>>();
            builder.RegisterType<ConsultantRepository>().As<IRepository<Consultant>>();
            builder.RegisterType<PersonRepository>().As<IRepository<Person>>();
            builder.RegisterType<SettingRepository>().As<IRepository<Setting>>();
            builder.RegisterType<SVRepository>().As<IRepository<SV>>();
            builder.RegisterType<SVActivityYearRepository>().As<IRepository<SVActivityYear>>();
            builder.RegisterType<SVUnitYearRepository>().As<IRepository<SVUnitYear>>();
            builder.RegisterType<TimeTableRepository>().As<IRepository<TimeTable>>();
            builder.RegisterType<UnitActivityRepository>().As<IRepository<UnitActivity>>();
            builder.RegisterType<UnitConsultRepository>().As<IRepository<UnitConsult>>();
            builder.RegisterType<YearRepository>().As<IRepository<Year>>();
            builder.RegisterType<UnitRepository>().As<IRepository<Unit>>();
            builder.RegisterType<UserRepository>().As<IRepository<User>>();
            builder.RegisterType<RoleRepository>().As<IRepository<Role>>();
            builder.RegisterType<UserInRoleRepository>().As<IRepository<UserInRole>>();
            builder.RegisterType<MasAmphurRepository>().As<IRepository<MasAmphur>>();
            builder.RegisterType<MasBusinessTypeRepository>().As<IRepository<MasBusinessType>>();
            builder.RegisterType<MasCareerTypeRepository>().As<IRepository<MasCareerType>>();
            builder.RegisterType<MasEducationTypeRepository>().As<IRepository<MasEducationType>>();
            builder.RegisterType<MasProvinceRepository>().As<IRepository<MasProvince>>();
            builder.RegisterType<MasSubBusinessTypeRepository>().As<IRepository<MasSubBusinessType>>();
            builder.RegisterType<MasTambolRepository>().As<IRepository<MasTambol>>();



            //Service>>>>Model
            builder.RegisterType<ActionTypeService>().AsSelf().As<IService<ActionType>>();
            builder.RegisterType<ActivityTypeService>().AsSelf().As<IService<ActivityType>>();
            builder.RegisterType<ActualWorkService>().AsSelf().As<IService<ActualWork>>();
            builder.RegisterType<ApplicantService>().AsSelf().As<IService<Applicant>>();
            builder.RegisterType<CompanyService>().AsSelf().As<IService<Company>>();
            builder.RegisterType<ConsultantService>().AsSelf().As<IService<Consultant>>();
            builder.RegisterType<PersonService>().AsSelf().As<IService<Person>>();
            builder.RegisterType<SettingService>().AsSelf().As<IService<Setting>>();
            builder.RegisterType<SVService>().AsSelf().AsSelf().As<IService<SV>>();
            builder.RegisterType<SVActivityYearService>().AsSelf().As<IService<SVActivityYear>>();
            builder.RegisterType<SVUnitYearService>().AsSelf().As<IService<SVUnitYear>>();
            builder.RegisterType<TimeTableService>().AsSelf().As<IService<TimeTable>>();
            builder.RegisterType<UnitActivityService>().AsSelf().As<IService<UnitActivity>>();
            builder.RegisterType<UnitConsultService>().AsSelf().As<IService<UnitConsult>>();
            builder.RegisterType<YearService>().AsSelf().As<IService<Year>>();
            builder.RegisterType<UnitService>().AsSelf().As<IService<Unit>>();
            builder.RegisterType<UserService>().AsSelf().As<IService<User>>();
            builder.RegisterType<RoleService>().AsSelf().As<IService<Role>>();
            builder.RegisterType<UserInRoleService>().AsSelf().As<IService<UserInRole>>();
            builder.RegisterType<MasAmphurService>().AsSelf().As<IService<MasAmphur>>();
            builder.RegisterType<MasBusinessTypeService>().AsSelf().As<IService<MasBusinessType>>();
            builder.RegisterType<MasCareerTypeService>().AsSelf().As<IService<MasCareerType>>();
            builder.RegisterType<MasEducationTypeService>().AsSelf().As<IService<MasEducationType>>();
            builder.RegisterType<MasProvinceService>().AsSelf().As<IService<MasProvince>>();
            builder.RegisterType<MasSubBusinessTypeService>().AsSelf().As<IService<MasSubBusinessType>>();
            builder.RegisterType<MasTambolService>().AsSelf().As<IService<MasTambol>>();



            builder.RegisterType<AppDbContext>().As<DbContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
