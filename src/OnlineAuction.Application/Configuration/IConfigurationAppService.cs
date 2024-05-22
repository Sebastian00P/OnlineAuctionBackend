using System.Threading.Tasks;
using OnlineAuction.Configuration.Dto;

namespace OnlineAuction.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
