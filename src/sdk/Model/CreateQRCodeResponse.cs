using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace WeChat.Model
{
    public class CreateQRCodeResponse
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }
        public string url { get; set; }

        /// <summary>
        /// 二维码地址图片
        /// </summary>
        public string ImgUrl =>  $"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={HttpUtility.UrlEncode(ticket)}";


    }
}
