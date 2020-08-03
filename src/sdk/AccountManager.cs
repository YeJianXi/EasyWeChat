using WeChat.Model;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeChat
{
    public class AccountManager
    {

        HttpClient _client;
        public AccountManager(HttpClient client)
        {
            this._client = client;
        }

        /// <summary>
        /// 获取临时二维码
        /// </summary>
        /// <typeparam name="TSceneType"></typeparam>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateQRCodeResponse> GetTempQRCode<TSceneType>(string accessToken, CreateTempQRCodeRequest<TSceneType> request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={accessToken}";

            HttpContent content = new StringContent(request.ToJson());

            return await this._client.PostAsync<CreateQRCodeResponse>(url, content);

        }

        /// <summary>
        /// 长链接转短链接
        /// </summary>
        /// <param name="longUrl"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<Long2ShortUrlResponse> LongUriToShortUri(string longUrl,string accessToken)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/shorturl?access_token={accessToken}";
            Dictionary<string, string> parm = new Dictionary<string, string>();
            parm["access_token"] = accessToken;
            parm["action"] = "long2short";
            parm["long_url"] = longUrl;
           return await  this._client.PostAsync<Long2ShortUrlResponse>(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(parm)));
 
        }
    }
}
