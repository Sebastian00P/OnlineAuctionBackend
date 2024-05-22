using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineAuction.EntityFrameworkCore;
using OnlineAuction.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OnlineAuction.Web.Tests
{
    [DependsOn(
        typeof(OnlineAuctionWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OnlineAuctionWebTestModule : AbpModule
    {
        public OnlineAuctionWebTestModule(OnlineAuctionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineAuctionWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OnlineAuctionWebMvcModule).Assembly);
        }
    }
}