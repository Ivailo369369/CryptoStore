namespace CryptoStore
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.Services.EmailService;
    using CryptoStore.Validation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting; 


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CryptoStoreDb>(options => options.UseSqlServer(ConfigurationData.ConnectionString));

            services.AddIdentity<User, IdentityRole>()
              .AddDefaultUI()
              .AddEntityFrameworkStores<CryptoStoreDb>()
              .AddDefaultTokenProviders();
            services.AddRazorPages();

            services.AddMvc();

            AddAplicationServices(services);

            services.AddHttpContextAccessor();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AdministrationValidation.ReadPolicy,
                    builder => builder.RequireRole(AdministrationValidation.Admin));
                options.AddPolicy(AdministrationValidation.WritePolicy,
                    builder => builder.RequireRole(AdministrationValidation.Admin));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false
                };

                options.SignIn.RequireConfirmedAccount = true;

                options.Lockout.AllowedForNewUsers = true;

            });

            services.AddSingleton<IEmailSender, SendGridEmailService>();
            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

        }

        private static void AddAplicationServices(IServiceCollection services)
             => services
                 .AddScoped<IServicesService, ServicesService>()
                 .AddScoped<IAdministrationService, AdministrationService>()
                 .AddScoped<IResourcesService, ResourcesService>()
                 .AddScoped<INewsletterService, NewsletterService>()
                 .AddScoped<IPaymentService, PaymentService>()
                 .AddScoped<ICurrentUserService, CurrentUserService>()
                 .AddScoped<IMessageNotificationService, MessageNotificationService>()
                 .AddScoped<IPartnerService, PartnerService>();
          

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
