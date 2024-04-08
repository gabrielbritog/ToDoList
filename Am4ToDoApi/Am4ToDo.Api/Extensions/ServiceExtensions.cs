using Am4ToDo.Domain.Interfaces.Service;
using Am4ToDo.Service.Services;

namespace Am4ToDo.Api.Extensions
{
    static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskToDoService, TaskToDoService>();
            return services;
        }
    }
}
