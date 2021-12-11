namespace CryptoStore
{
    using CryptoStore.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages();

            services
                .AddDatabase()
                .AddIdentity()
                .AddAuthorizations()
                .AddApplicationServices()
                .AddSwagger()
                .AddApiControllers(); 
                
            services.AddEmailSender(this.Configuration);    

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app
                .UseSwaggerUI()
                .UseStaticFiles()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                 .UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");
                     endpoints.MapRazorPages();
                 })
                 .ApplyMigrations();       
        }
    }
}
