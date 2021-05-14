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
    using EasyWeChat.Model;
    using Interface;
    using Microsoft.Extensions.Logging;

    public class CustomMessageService : WeiXinApiBaseService, ICustomMessageService
    {

        ILogger _logger;
        public CustomMessageService(IHttpClientFactory clientFactory, ILogger<CustomMessageService> logger) : base(clientFactory)
        {
            _logger = logger;
        }

        public async Task<Result> SendAsync(string token, string touser, CustomMessage message)
        {
            if (message == null)
            {
                return Result.Fail("the message can not be null.");
            }
            try
            {
                string url = $@"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={token}";
                message.SetToUser(touser);
                string msgJson = message.ToJson();
                HttpContent content = new StringContent(msgJson);
                string result = await _client.PostAsync(url, content, _logger);
                if (string.IsNullOrEmpty(result))
                {
                    return Result.Fail("server may be has error.");
                }
                var jobj = JObject.Parse(result);
                if (jobj.TryGetValue("errcode", out JToken value))
                {
                    int errcode = value.Value<int>();
                    if (errcode == 0)
                    {
                        return Result.Success();
                    }
                    else
                    {
                        return Result.Fail(result);
                    }
                }
                else
                {
                    return Result.Fail("the result can not found errcode property.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result Send(string token, string touser, CustomMessage message)
        {
            return SendAsync(token, touser, message).GetAwaiter().GetResult();
        }
    }




}
