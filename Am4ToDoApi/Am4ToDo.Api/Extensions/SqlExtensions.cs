using Am4ToDo.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Am4ToDo.Api.Extensions
{
    static class SqlExtensions
    {
        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["DevNetStoreDatabase:ConnectionString"];
            services.AddDbContext<Am4ToDoContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Am4ToDo.Api")));
            return services;
        }
        }
}
