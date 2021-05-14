using EasyWeChat.Implement;
using EasyWeChat.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class IAccessTokenServiceTest
    {
        [TestMethod]
        public async Task Test_GetToken()
        {
            string appid = "wx0fc4ee9e61fbabd6", secret = "759081f722cdc7205b294db83b6b9937";
            ServiceCollection services = new ServiceCollection();
            services.AddEasyWeChat();
            IServiceProvider sp = services.BuildServiceProvider();
            IAccessTokenService accessTokenService = sp.GetService<IAccessTokenService>();
            var result =  await accessTokenService.GetToken(appid, secret);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.access_token);

        }

        [TestMethod]
        public async Task Test_GetTicket()
        {
            string appid = "wx0fc4ee9e61fbabd6", secret = "759081f722cdc7205b294db83b6b9937";
            ServiceCollection services = new ServiceCollection();
            services.AddEasyWeChat();
            IServiceProvider sp = services.BuildServiceProvider();
            IAccessTokenService accessTokenService = sp.GetService<IAccessTokenService>();
            var tokenResult = await accessTokenService.GetToken(appid, secret);
            var ticketResult = await accessTokenService.GetTicket(tokenResult.access_token);
            Assert.IsNotNull(ticketResult);
            Assert.IsNotNull(ticketResult.ticket);

        }

    }
}
