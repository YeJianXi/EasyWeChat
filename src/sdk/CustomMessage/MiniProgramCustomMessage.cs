using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{


    /// <summary>
    /// 小程序卡片消息
    /// </summary>
    public class MiniProgramCardMessage : CustomMessage
    {
        IDictionary<string, string> miniprogrampage = new Dictionary<string, string>();

        public MiniProgramCardMessage()
        {
            base.postData.Add("msgtype", "miniprogrampage");
            base.postData.Add("miniprogrampage", miniprogrampage);
        }


        public void SetTitle(string title)
        {
            miniprogrampage["title"] = title;
        }
        public void SetAppId(string appid)
        {
            miniprogrampage["appid"] = appid;
        }
        public void SetPagePath(string pagepath)
        {
            miniprogrampage["pagepath"] = pagepath;
        }
        public void SetThumbMediaId(string thumbMediaId)
        {
            miniprogrampage["thumb_media_id"] = thumbMediaId;
        }

    }
}
