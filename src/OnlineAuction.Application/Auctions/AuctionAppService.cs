using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAuction.Auctions.Dto;
using OnlineAuction.Authorization;
using OnlineAuction.Authorization.Roles;
using OnlineAuction.Offers;
using OnlineAuction.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineAuction.Auctions
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class AuctionAppService : ApplicationService, IAuctionAppService
    {
        private readonly IRepository<Offer, long> _repository;
        public AuctionAppService(IRepository<Offer, long> repository)
        {
            _repository = repository;
        }
        [HttpPost]       
        public async Task CreateAsync(CreateOfferDto input)
        {
            try
            {
                var offer = ObjectMapper.Map<Offer>(input);
                offer.CreationTime = DateTime.Now;
                offer.IsActive = true;
                if (AbpSession.UserId != null)
                {
                    offer.CreatorUserId = (long)AbpSession.UserId;
                }
                else
                {
                    throw new Exception("User not logged");
                }
                await _repository.InsertAsync(offer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task DeleteAsync(EntityDto<long> input)
        {
            try
            {
                var offerToRemove = ObjectMapper.Map<Offer>(input);
                await _repository.DeleteAsync(offerToRemove);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]    
        public async Task<List<OfferDto>> GetAllAsync(long input)
        {
            try
            {
                var offers = await _repository.GetAll().Where(x => x.IsActive).ToListAsync();
                return new List<OfferDto>(ObjectMapper.Map<List<OfferDto>>(offers));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<OfferDto> GetAsync(EntityDto<long> input)
        {
            try
            {
                var offer = await _repository.GetAsync(input.Id);
                return ObjectMapper.Map<OfferDto>(offer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task UpdateAsync(OfferDto offerDto)
        {
            try
            {
                if (AbpSession.UserId != null)
                {
                    offerDto.CreatorUserId = (long)AbpSession.UserId;
                }
                else
                {
                    throw new Exception("User not logged");
                }
                var existingOffer = await _repository.GetAll().FirstOrDefaultAsync(o => o.Id == offerDto.Id);
                ObjectMapper.Map(offerDto, existingOffer);
                await _repository.UpdateAsync(existingOffer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
