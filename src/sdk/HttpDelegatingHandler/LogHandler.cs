using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyWeChat.HttpDelegatingHandler
{
    public class LogHandler: DelegatingHandler
    {

        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            //before request
           var response = base.SendAsync(request, cancellationToken);
            //after request
            return response;
        }
    }
}
