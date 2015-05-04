using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Codestruction.Application.Config;
using Codestruction.Infrastructure.Filmbank.Infrastructure;
using Umbraco.Web;

namespace Codestruction.Web
    {
        public static class Bootstrap
        {
            public static void Init()
            {

                var builder = new ContainerBuilder();

                // Custom modules
                RegisterModules(builder);

                // Umbraco related stuff
                builder.Register(c => UmbracoContext.Current).AsSelf();
                builder.RegisterControllers(new[]
                {
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load("Codestruction.Application"),
                });

                builder.RegisterApiControllers(new[]
                {
                    typeof (UmbracoApplication).Assembly,
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load("Codestruction.Application"),
                });


                var container = builder.Build();
                IoC.Init(container);

                var resolver = new AutofacWebApiDependencyResolver(container);
                GlobalConfiguration.Configuration.DependencyResolver = resolver;
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            }


            private static void RegisterModules(ContainerBuilder builder)
            {
                var modules = new IModule[]
            {
                    new ApplicationModule(),  
            
            };

                foreach (var module in modules)
                    builder.RegisterModule(module);
            }
        }
    
}