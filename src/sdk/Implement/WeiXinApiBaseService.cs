using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EasyWeChat.Implement
{
    public abstract class WeiXinApiBaseService
    {

        protected HttpClient _client;
        public WeiXinApiBaseService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(Config.HttpClientName);
        }
    }
}
