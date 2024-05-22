using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineAuction.Configuration;

namespace OnlineAuction.Web.Host.Startup
{
    [DependsOn(
       typeof(OnlineAuctionWebCoreModule))]
    public class OnlineAuctionWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OnlineAuctionWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineAuctionWebHostModule).GetAssembly());
        }
    }
}
