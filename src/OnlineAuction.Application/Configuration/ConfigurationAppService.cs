using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OnlineAuction.Configuration.Dto;

namespace OnlineAuction.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OnlineAuctionAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
