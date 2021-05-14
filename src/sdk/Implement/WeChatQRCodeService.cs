
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeChat.Interface;
using WeChat.Model;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace WeChat.Implement
{

    public class WeChatQRCodeService : IWeChatQRCodeService
    {
        HttpClient _client;
        ILogger _logger;

        public WeChatQRCodeService(HttpClient client, ILogger<WeChatQRCodeService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<CreateQRCodeResponse> GenerateTempQRCode<TSceneType>(string accessToken, CreateTempQRCodeRequest<TSceneType> request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={accessToken}";

            HttpContent content = new StringContent(request.ToJson());

            return await _client.PostAsync<CreateQRCodeResponse>(url, content, _logger);
        }

        public async Task<GetWXAcodeUnlimitResult> GetWXAcodeUnlimit(string accessToken, GetWXAcodeUnlimitRequest request)
        {
            string url = $"https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={accessToken}";
            string jsonParms = JsonConvert.SerializeObject(request,new JsonSerializerSettings() {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            });
            HttpContent httpContent = new StringContent(jsonParms);
            var response = await _client.PostAsync(url, httpContent);
            GetWXAcodeUnlimitResult resutlt = new GetWXAcodeUnlimitResult();
            response.EnsureSuccessStatusCode();
            resutlt.ContentType = response.Content.Headers.ContentType.ToString();
            if (response.Content.Headers.ContentType.MediaType.Equals("application/json", StringComparison.CurrentCultureIgnoreCase))
            {
                var jobj = JObject.Parse(await response.Content.ReadAsStringAsync());
                resutlt.ErrCode = jobj.Value<int>("errcode");
                resutlt.ErrMsg = jobj.Value<string>("errmsg");
            }
            else {
                resutlt.Buffer = await response.Content.ReadAsByteArrayAsync();
            }

            return resutlt;
        }
    }
}
