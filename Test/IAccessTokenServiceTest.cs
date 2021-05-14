using EasyWeChat.Implement;
using EasyWeChat.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class IAccessTokenServiceTest:BaseTest
    {
        [TestMethod]
        public async Task Test_GetToken()
        {
            IAccessTokenService accessTokenService = _sp.GetService<IAccessTokenService>();
            var result =  await accessTokenService.GetToken(Config.AppId, Config.AppSecret);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.access_token);

        }

        [TestMethod]
        public async Task Test_GetTicket()
        {
            IAccessTokenService accessTokenService = _sp.GetService<IAccessTokenService>();
            var tokenResult = await accessTokenService.GetToken(Config.AppId, Config.AppSecret);
            var ticketResult = await accessTokenService.GetTicket(tokenResult.access_token);
            Assert.IsNotNull(ticketResult);
            Assert.IsNotNull(ticketResult.ticket);

        }

    }
}
