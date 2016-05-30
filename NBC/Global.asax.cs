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

namespace NBC {
  public class MvcApplication : System.Web.HttpApplication {
    protected void Application_Start() {

      initAutoFac();

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    private void initAutoFac() {
      var builder = new ContainerBuilder();

      builder.RegisterControllers(typeof(MvcApplication).Assembly);
      builder.RegisterType<YearRepository>().As<IRepository<Year>>();
      builder.RegisterType<YearService>().As<IService<Year>>(); 
      builder.RegisterType<AppDbContext>().As<DbContext>(); 

      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
  }
}
