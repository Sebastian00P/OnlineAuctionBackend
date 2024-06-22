using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineAuction.Offers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuction.Auctions.Dto
{
    [AutoMapFrom(typeof(Offer))]
    public class OfferDto :EntityDto<long>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsActive { get; set; }
        public long CreatorUserId { get; set; }
    }
}
