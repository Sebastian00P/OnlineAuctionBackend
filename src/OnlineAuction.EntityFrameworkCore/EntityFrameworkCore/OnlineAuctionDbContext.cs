using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OnlineAuction.Authorization.Roles;
using OnlineAuction.Authorization.Users;
using OnlineAuction.MultiTenancy;
using OnlineAuction.Offers;
using Abp.Domain.Repositories;

namespace OnlineAuction.EntityFrameworkCore
{
    public class OnlineAuctionDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineAuctionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Offer> Offers { get; set; }
        public OnlineAuctionDbContext(DbContextOptions<OnlineAuctionDbContext> options)
            : base(options)
        {
        }
    }
}
