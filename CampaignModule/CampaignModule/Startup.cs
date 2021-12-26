using Business.Concrete.DependencyResolver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusinessDependencyInjectionModule();
        }
    }
}
