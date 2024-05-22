using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OnlineAuction.EntityFrameworkCore
{
    public static class OnlineAuctionDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OnlineAuctionDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OnlineAuctionDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
