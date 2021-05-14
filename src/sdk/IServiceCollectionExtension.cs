using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;
using WeChat;
using WeChat.Implement;
using WeChat.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {

        public static void AddEasyWeChat(this IServiceCollection services)
        {

            services.AddHttpClient<IWeChatQRCodeService, WeChatQRCodeService>()
                .AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(new[]
              {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                }));

            services.AddHttpClient<ITemplateMessageService, TemplateMessageService>()
                .AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(new[]
              {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                }));
        }




        public static void AddWeChatQRCodeService(this IServiceCollection services)
        {
            services.AddHttpClient<IWeChatQRCodeService, WeChatQRCodeService>()
                .AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(new[]
              {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                }));
        }
    }
}
