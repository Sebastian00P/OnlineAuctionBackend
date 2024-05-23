using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuction.Auctions.Dto
{
    public class PagedOfferResulRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
