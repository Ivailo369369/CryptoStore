namespace CryptoStore.Infrastructure.Services
{
    using CryptoStore.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => this.user = httpContextAccessor.HttpContext?.User;

        public string GetUsername()
           => this.user?.Identity?.Name;

        public string GetId()  
           => this.user?.GetUserId();
    }
}
