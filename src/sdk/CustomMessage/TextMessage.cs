using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{

    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : CustomMessage
    {


        public TextMessage()
        {
            base.postData.Add("msgtype", "text");
        }

        public void SetContent(string content)
        {
            this.postData.Add("text", new
            {
                content = content
            });
        }

    }

}
