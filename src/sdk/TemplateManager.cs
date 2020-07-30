using Newtonsoft.Json;
using sdk.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
            var response = await this._client.GetAsync<TemplateListResponse>(url);
            return response;
        }

        public async Task<bool> DeleteTemplate(string accessToken, string templateId)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={accessToken}";

            object postObj = new
            {
                template_id = templateId
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(postObj));
            var response = await this._client.PostAsync<StatusResponse>(url, content);
            if (response != null)
            {
                return response.errcode == ResponseCodeEnum.success;
            }
            else
            {
                return false;
            }
        }

        public async Task<SendTemplateResponse> SendAsync(string accessToken, SendTemplateRequest input)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={accessToken}";
            SendTemplateResponse response = await this._client.PostAsync<SendTemplateResponse>(url, new StringContent(input.ToJson()));
            return response;
        }



    }
}
