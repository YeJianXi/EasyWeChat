using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeChat.Interface
{
    using CustomMessage;
    public interface ICustomMessageService
    {
        Task<bool> Send(string token, string touser, CustomMessage message);
     }
}
