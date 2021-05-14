using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class GetWXAcodeUnlimitResult
    {

        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public string ContentType { get; set; }
        public byte[] Buffer { get; set; }

    }
}
