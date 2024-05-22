using Abp.Authorization;
using OnlineAuction.Authorization.Roles;
using OnlineAuction.Authorization.Users;

namespace OnlineAuction.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
