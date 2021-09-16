namespace CryptoStore.Infrastructure.Extensions
{
    using CryptoStore.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBulderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
      => app
          .UseSwagger()
          .UseSwaggerUI(options =>
          {
              options.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoStore API");
          });

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<CryptoStoreDb>();

            dbContext.Database.Migrate();
        }
    }
}
