using Microsoft.AspNetCore.Hosting; 

[assembly: HostingStartup(typeof(CryptoStore.Areas.Identity.IdentityHostingStartup))] 
namespace CryptoStore.Areas.Identity
{ 
    using Microsoft.AspNetCore.Hosting;

    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
        }
    }
}