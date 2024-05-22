using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineAuction.Configuration;
using OnlineAuction.EntityFrameworkCore;
using OnlineAuction.Migrator.DependencyInjection;

namespace OnlineAuction.Migrator
{
    [DependsOn(typeof(OnlineAuctionEntityFrameworkModule))]
    public class OnlineAuctionMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public OnlineAuctionMigratorModule(OnlineAuctionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(OnlineAuctionMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                OnlineAuctionConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineAuctionMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
