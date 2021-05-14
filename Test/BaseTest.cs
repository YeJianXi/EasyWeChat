using EasyWeChat.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class BaseTest
    {
       protected IServiceProvider _sp;
        public BaseTest()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddEasyWeChat();
            _sp  = services.BuildServiceProvider();

        }

        public async Task<string> GetAccessToken()
        {
            IAccessTokenService accessTokenService = _sp.GetService<IAccessTokenService>();
           var result = await accessTokenService.GetToken(Config.AppId, Config.AppSecret);
            return result.access_token;
        }
    }
}
