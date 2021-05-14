using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class SendTemplateResponse:StatusResponse
    {
        public long msgid { get; set; }
    }
}
