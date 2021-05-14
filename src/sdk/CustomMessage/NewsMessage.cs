using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{


    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsMessage : CustomMessage
    {
        Dictionary<string, Dictionary<string, object>[]> news = new Dictionary<string, Dictionary<string, object>[]>();

        public NewsMessage()
        {
            news["articles"] = new Dictionary<string, object>[] { new Dictionary<string, object>() };
            base.postData.Add("msgtype", "news");
            base.postData["news"] = news;
        }

        public void SetTitle(string title)
        {
            news["articles"][0].Add("title", title);
        }

        public void SetDescription(string description)
        {
            news["articles"][0].Add("description", description);
        }

        public void SetUrl(string url)
        {
            news["articles"][0].Add("url", url);
        }

        public void SetPicUrl(string picUrl)
        {
            news["articles"][0].Add("picurl", picUrl);
        }

    }

}
