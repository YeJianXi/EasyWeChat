using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class GetTicketResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}
