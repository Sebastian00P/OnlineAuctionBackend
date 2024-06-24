using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
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
    public class AuctionAppService : ApplicationService, IAuctionAppService, IDomainService
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
                var offer = new Offer();
                offer.Description = input.Description;
                offer.Price = input.Price;
                offer.Title = input.Title;
                offer.Photo = input.Photo;
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
        public async Task DeleteAsync(long input)
        {
            try
            {
                var offerToRemove = _repository.FirstOrDefault(x => x.Id == input);
                offerToRemove.IsActive = false;
                await _repository.UpdateAsync(offerToRemove);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]    
        public async Task<List<OfferDto>> GetAllAsync()
        {
            try
            {
                var offersdto = await _repository.GetAll().Where(x => x.IsActive).ToListAsync();
                var offers = new List<OfferDto>();
                foreach (var offer in offersdto)
                {
                    offers.Add(new OfferDto()
                    {
                        Photo = offer.Photo,
                        CreationTime = offer.CreationTime,
                        CreatorUserId = offer.CreatorUserId,
                        Description = offer.Description,
                        Id = offer.Id,
                        IsActive = offer.IsActive,
                        Price = offer.Price,
                        Title = offer.Title
                    });
                }
                return offers;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<OfferDto> GetAsync(long input)
        {
            try
            {
                var offer = await _repository.GetAsync(input);
                var offerDto = new OfferDto()
                {
                    CreationTime = offer.CreationTime,
                    CreatorUserId = offer.CreatorUserId,
                    Title = offer.Title,
                    Price = offer.Price,
                    IsActive = offer.IsActive,
                    Id = offer.Id,
                    Description = offer.Description,
                    Photo = offer.Photo
                };
                return offerDto;
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
                existingOffer.Description = offerDto.Description;
                existingOffer.Price = offerDto.Price;               
                existingOffer.Photo = offerDto.Photo;
                existingOffer.Title = offerDto.Title;              

                await _repository.UpdateAsync(existingOffer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
