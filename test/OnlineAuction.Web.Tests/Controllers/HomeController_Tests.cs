using System.Threading.Tasks;
using OnlineAuction.Models.TokenAuth;
using OnlineAuction.Web.Controllers;
using Shouldly;
using Xunit;

namespace OnlineAuction.Web.Tests.Controllers
{
    public class HomeController_Tests: OnlineAuctionWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}