using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class StatusResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public ResponseCodeEnum errcode { get; set; }

        public string errmsg { get; set; }
    }
}

