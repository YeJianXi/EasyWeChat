using sdk.Model;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sdk
{
    public class AccountManager
    {

        HttpClient _client;
        public AccountManager(HttpClient client)
        {
            this._client = client;
        }

        public async Task<CreateQRCodeResponse> GetTempQRCode<TSceneType>(string accessToken, CreateTempQRCodeRequest<TSceneType> request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={accessToken}";

            HttpContent content = new StringContent(request.ToJson());

            return await this._client.PostAsync<CreateQRCodeResponse>(url, content);

        }
    }
}
