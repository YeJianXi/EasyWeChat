using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeChat.Interface
{
    using CustomMessage;
    using EasyWeChat.Model;

    public interface ICustomMessageService
    {
        Task<Result> SendAsync(string token, string touser, CustomMessage message);

        Result Send(string token, string touser, CustomMessage message);
    }
}
