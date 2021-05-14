using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyWeChat.Interface;
using EasyWeChat.Model;

namespace EasyWeChat.Implement
{
    public class TemplateMessageService: ITemplateMessageService
    {
        HttpClient _client;
        ILogger _logger;
        public TemplateMessageService(HttpClient client,ILogger<TemplateMessageService> logger)
        {
            this._client = client;
            this._logger = logger;

        }

        public async Task<TemplateListResponse> GetTemplates(string accessToken)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={accessToken}";
            var response = await this._client.GetAsync<TemplateListResponse>(url,_logger);
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
            var response = await this._client.PostAsync<StatusResponse>(url, content, _logger);
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
            SendTemplateResponse response = await this._client.PostAsync<SendTemplateResponse>(url, new StringContent(input.ToJson()), _logger);
            return response;
        }

    }
}
