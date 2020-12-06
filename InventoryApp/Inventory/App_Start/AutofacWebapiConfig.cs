using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Inventory.Data.Infrastructure;
using Inventory.Models;
using Inventory.Service;
using ProductReview.Data.Infrastructure;
using ProductReview.Data.Repositories;
using System.Reflection;
using System.Web.Http;

namespace Inventory.App_Start
{
    public class AutofacWebapiConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IMapper mapper = AutoMapperConfiguration.Configure();

            builder.RegisterInstance<IMapper>(mapper);
            //Set the dependency resolver to be Autofac.  
            IContainer container = builder.Build();

            return container;
        }
    }
}