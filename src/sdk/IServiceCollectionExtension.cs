using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;
using EasyWeChat;
using EasyWeChat.Implement;
using EasyWeChat.Interface;
using System.Reflection;
using System.Net.Http;
using System.Linq;
using EasyWeChat.HttpDelegatingHandler;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {

        public static void AddEasyWeChat(this IServiceCollection services)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<LogHandler>();
            services.AddHttpClient(Config.HttpClientName)
                .AddHttpMessageHandler<LogHandler>()
                .SetHandlerLifetime(TimeSpan.FromHours(10000))
                .AddPolicyHandler(request =>  Policy.TimeoutAsync<HttpResponseMessage>(30))
                .AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(new[] {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)})) //重试3次，第一次1秒间隔，第二次2秒间隔，第三次3秒间隔。
                .AddTransientHttpErrorPolicy(p=>p.CircuitBreakerAsync(5,TimeSpan.FromSeconds(30))); //添加熔断策略，配合上面重试机制连续5遍后，打断后面请求操作，一个周期30秒
           var implements =  assembly.GetTypes().Where(t => !t.IsGenericType && t.IsClass && !t.IsAbstract && t.FullName.IndexOf("EasyWeChat.Implement") !=-1);
            foreach (var implement in implements)
            {
               var interfaces = implement.GetInterfaces();
                foreach (var _interface in interfaces)
                {
                    services.AddScoped(_interface, implement);
                }
            }

       
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
