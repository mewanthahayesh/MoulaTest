using System.Reflection;
using AutoMapper;
using BIRuleProcessor.Mapppers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoulaCustomers.DIContainer;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace MoulaCustomers
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurationService(IServiceCollection services)
        {
            var mapping = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration() );
            });
            
            services.Configure<Services.ConfigSettings>(Configuration.GetSection("ConfigSettings"));
            ContainerInjector.Config(services,Configuration);
            services.AddSingleton(mapping.CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }
    }
}