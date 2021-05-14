using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class StartTimingGetTokenOutput
    {
        /// <summary>
        /// 微信公众平台接口服务调用凭据
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 微信浏览器接口调用凭据
        /// </summary>
        public string JSAPITicket { get; set; }
    }
}
