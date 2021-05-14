using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeChat.Implement
{
    using CustomMessage;
    using Interface;
    using Microsoft.Extensions.Logging;

    public  class CustomMessageService: ICustomMessageService
    {

        ILogger _logger;
        public CustomMessageService(ILogger<CustomMessageService> logger)
        {
            _logger = logger;
        }

        public virtual async Task<bool> Send(string token,string touser, CustomMessage message)
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $@"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={token}";

                    HttpContent content = new StringContent(message.ToJson());
                    string result = await client.PostAsync(url, content, _logger);
                    if (string.IsNullOrEmpty(result)) {
                        return false;
                    }
                    var jobj = JObject.Parse(result);
                    if (jobj.TryGetValue("errcode", out JToken value))
                    {
                        int errcode = value.Value<int>();
                        return errcode == 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }




}
