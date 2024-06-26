﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace OnlineAuction.Authorization
{
    public class OnlineAuctionAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Auction, L("Auction"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OnlineAuctionConsts.LocalizationSourceName);
        }
    }
}
