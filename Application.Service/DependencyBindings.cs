using Application.Service.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Service
{
    public static class DependencyBindings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserIdentityService, UserIdentityService>();
            services.AddTransient<ISeminarService, SeminarService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
        }
    }
}
