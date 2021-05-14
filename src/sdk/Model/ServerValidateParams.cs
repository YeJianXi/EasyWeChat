using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class ServerValidateParams
    {

        /// <summary>
        /// 定义校验的秘密Token
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 输出字符串，验证通过后返回
        /// </summary>
        public string echostr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; }
    }
}
