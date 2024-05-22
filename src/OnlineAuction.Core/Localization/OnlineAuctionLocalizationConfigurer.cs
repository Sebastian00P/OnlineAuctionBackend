using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OnlineAuction.Localization
{
    public static class OnlineAuctionLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OnlineAuctionConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OnlineAuctionLocalizationConfigurer).GetAssembly(),
                        "OnlineAuction.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
