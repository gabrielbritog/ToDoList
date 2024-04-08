using Am4ToDo.Domain.Interfaces.Repository;
using Am4ToDo.Domain.Models;
using Am4ToDo.Infra.Repository;

namespace Am4ToDo.Api.Extensions
{
    static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();
            return services;

        }
    }
}
