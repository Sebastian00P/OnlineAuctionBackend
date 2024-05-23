using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OnlineAuction.Authorization.Roles;
using OnlineAuction.Authorization.Users;
using OnlineAuction.MultiTenancy;
using OnlineAuction.Offers;

namespace OnlineAuction.EntityFrameworkCore
{
    public class OnlineAuctionDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineAuctionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        DbSet<Offer> Offers { get; set; }
        public OnlineAuctionDbContext(DbContextOptions<OnlineAuctionDbContext> options)
            : base(options)
        {
        }
    }
}
