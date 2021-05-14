using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{
   public  class VideoMessage: CustomMessage
    {
        IDictionary<string, string> video = new Dictionary<string, string>();
        public VideoMessage()
        {
            base.postData["msgtype"] = "video";
            base.postData["video"] = video;
        }

        public void SetMediaId(string mediaId)
        {
            video["media_id"] = mediaId;
        }
        public void SetThumbMediaId(string thumbMediaId)
        {
            video["thumb_media_id"] = thumbMediaId;
        }
        public void SetTitle(string title)
        {
            video["title"] = title;
        }
        public void SetDescription(string description)
        {
            video["description"] = description;
        }

    }
}
