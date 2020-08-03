using System;
using System.Collections.Generic;
using System.Text;

namespace WeChat.Model
{
    public class SendTemplateResponse:StatusResponse
    {
        public long msgid { get; set; }
    }
}
