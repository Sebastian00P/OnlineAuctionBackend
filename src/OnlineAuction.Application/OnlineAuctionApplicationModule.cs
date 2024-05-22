using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineAuction.Authorization;

namespace OnlineAuction
{
    [DependsOn(
        typeof(OnlineAuctionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OnlineAuctionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OnlineAuctionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OnlineAuctionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
