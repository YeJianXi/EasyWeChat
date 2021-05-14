using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{
    public class ImageMessage:CustomMessage
    {
        IDictionary<string, string> image = new Dictionary<string, string>();
        public ImageMessage()
        {
            base.postData.Add("msgtype", "image");
            base.postData.Add("image", image);
        }
        public void SetMediaId(string mediaId)
        {
            image["media_id"] = mediaId;
        }
    }
}
