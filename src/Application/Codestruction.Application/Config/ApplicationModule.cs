using System.Security.Policy;
using Autofac;
using Codestruction.Application.Context;
using Codestruction.Application.Factories;
using Codestruction.Application.Services;
using Codestruction.Domain.Blog;
using Codestruction.Infrastructure.Umbraco;

namespace Codestruction.Application.Config
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppContext>().As<IAppContext>().InstancePerDependency().PropertiesAutowired();

            builder.RegisterType<UrlManager>().As<IUrlManager>().InstancePerDependency();
            builder.RegisterType<BlogDao>().As<IBlogDao>().InstancePerDependency();
             builder.RegisterType<BlogFactory>().AsSelf();
            builder.RegisterType<BlogService>().AsSelf();
            builder.RegisterType<WidgetService>().AsSelf();
        }

    }
}
