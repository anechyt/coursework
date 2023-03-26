using Coursework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static async Task<IServiceCollection> AddDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db:DefaultConnectionString"];
            services.AddDbContext<CoursworkContext>(options =>
                options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(CoursworkContext).Assembly.FullName)));

            return services;
        }
    }
}
