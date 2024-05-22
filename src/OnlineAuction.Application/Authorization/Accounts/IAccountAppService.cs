using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineAuction.Authorization.Accounts.Dto;

namespace OnlineAuction.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
