using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EventsSchedule.Web.Areas.Identity.IdentityHostingStartup))]

namespace EventsSchedule.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
