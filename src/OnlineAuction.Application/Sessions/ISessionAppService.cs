using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineAuction.Sessions.Dto;

namespace OnlineAuction.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
