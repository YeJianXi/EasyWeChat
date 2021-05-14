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

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {

        public static void AddEasyWeChat(this IServiceCollection services)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            services.AddHttpClient(Config.HttpClientName)
                .AddPolicyHandler(request => Policy.TimeoutAsync<HttpResponseMessage>(30))
                .AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(new[]
               {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                }));
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
