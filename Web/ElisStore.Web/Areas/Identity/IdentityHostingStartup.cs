using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ElisStore.Web.Areas.Identity.IdentityHostingStartup))]

namespace ElisStore.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}