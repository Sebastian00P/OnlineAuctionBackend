using Abp.Application.Services.Dto;

namespace OnlineAuction.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

