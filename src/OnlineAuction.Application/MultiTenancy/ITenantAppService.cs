using Abp.Application.Services;
using OnlineAuction.MultiTenancy.Dto;

namespace OnlineAuction.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

