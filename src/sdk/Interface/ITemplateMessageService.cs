using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyWeChat.Model;

namespace EasyWeChat.Interface
{
    public interface ITemplateMessageService
    {
        Task<TemplateListResponse> GetTemplates(string accessToken);
        Task<bool> DeleteTemplate(string accessToken, string templateId);
        Task<SendTemplateResponse> SendAsync(string accessToken, SendTemplateRequest input);
    }
}
