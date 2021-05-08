using Application.Repository.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Repository
{
    public static class DependencyBindings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ISeminarRepository, SeminarRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IGenericRepository, GenericRepository>();
        }
    }
}
