using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OnlineAuction.Controllers
{
    public abstract class OnlineAuctionControllerBase: AbpController
    {
        protected OnlineAuctionControllerBase()
        {
            LocalizationSourceName = OnlineAuctionConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
