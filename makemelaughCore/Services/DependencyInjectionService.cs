using makemelaughCore.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makemelaughCore.Services
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection BindServices(this IServiceCollection services, bool isScoped = true)          
        {
            // #degreed
            // We are registering this as Scoped, so that this will create instance everytime it is invoked.
            // This helps, because if for some reason an exception is encountered, then only that instance of this service is impacted.
            // fresh request will have fresh instance.
            if (isScoped)
            {
                services.AddScoped(typeof(MakeMeLaughServiceContract), typeof(MakeMeLaughService));         
            }
            // #degreed
            // we have given provision to register it as singleton.
            // this will use single instance of this service across all requests.
            // this can be hazardous, if one request has exception, then whole instance of this service might crash, resulting in service 
            // unavailability.
            // Also this will continue to hold memory in RAM, even if the service is idle.
            else
            {
                services.AddSingleton(typeof(MakeMeLaughServiceContract), typeof (MakeMeLaughService));            
            }
            return services;
        }
    }
}
