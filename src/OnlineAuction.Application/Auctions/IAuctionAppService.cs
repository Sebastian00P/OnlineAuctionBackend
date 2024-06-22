using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineAuction.Auctions.Dto;
using OnlineAuction.Offers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineAuction.Auctions
{
    public interface IAuctionAppService : IApplicationService
    {
        Task CreateAsync(CreateOfferDto input);
        Task DeleteAsync(EntityDto<long> input);
        Task<List<OfferDto>> GetAllAsync();
        Task<OfferDto> GetAsync(EntityDto<long> input);
        Task UpdateAsync(OfferDto offerDto);
    }
}