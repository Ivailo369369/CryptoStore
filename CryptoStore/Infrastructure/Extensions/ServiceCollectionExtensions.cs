namespace CryptoStore.Infrastructure.Extensions
{
    using CryptoStore.Data;
    using CryptoStore.Data.Models;
    using CryptoStore.Infrastructure.Services;
    using CryptoStore.Services;
    using CryptoStore.Services.Contracts;
    using CryptoStore.Services.EmailService;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using static Infrastructure.WebConstants;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
           this IServiceCollection services)
           => services
               .AddDbContext<CryptoStoreDb>(options => options
                   .UseSqlServer(ConfigurationData.ConnectionString));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequiredUniqueChars = 1; 
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddDefaultUI()
                .AddEntityFrameworkStores<CryptoStoreDb>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAuthorizations(this IServiceCollection services)
            => services
                .AddAuthorization(options =>
                {
                   options.AddPolicy(ReadPolicy,
                       builder => builder.RequireRole(Admin));
                   options.AddPolicy(WritePolicy,
                       builder => builder.RequireRole(Admin));
                });

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
         => services
                 .AddScoped<IServicesService, ServicesService>()
                 .AddScoped<IAdministrationService, AdministrationService>()
                 .AddScoped<IResourcesService, ResourcesService>()
                 .AddScoped<INewsletterService, NewsletterService>()
                 .AddScoped<IPaymentService, PaymentService>()
                 .AddScoped<ICurrentUserService, CurrentUserService>()
                 .AddScoped<IMessageNotificationService, MessageNotificationService>()
                 .AddScoped<IPartnerService, PartnerService>();

        public static SendGridOptions AddEmailSender(
            this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddSingleton<IEmailSender, SendGridEmailService>();

            var emailSettingsConfiguration = configuration.GetSection("EmailSettings"); 
            services.Configure<SendGridOptions>(emailSettingsConfiguration);
            return emailSettingsConfiguration.Get<SendGridOptions>();
        }
    }
}
