using sdk.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sdk
{
    /// <summary>
    /// 模板消息管理者
    /// </summary>
    public class TemplateManager
    {
        HttpClient _client;
        public TemplateManager(HttpClient client)
        {
            this._client = client;

        }

        public async Task<TemplateListResponse> GetTemplates(string accessToken)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={accessToken}";
            var response = await this._client.GetJson<TemplateListResponse>(url);
            return response;
        }
    }
}
