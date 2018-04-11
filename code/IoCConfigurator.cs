using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Feature.Blog.Controllers;
using Sitecore.Feature.Blog.Repositories;

namespace Sitecore.Feature.Blog
{
    public class IoCConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBlogRepository, BlogRepository>();
            serviceCollection.AddTransient<BlogController>();
        }
    }
}
