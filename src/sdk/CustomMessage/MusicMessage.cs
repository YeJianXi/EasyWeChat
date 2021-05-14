using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{
    public class MusicMessage : CustomMessage
    {


        IDictionary<string, string> music = new Dictionary<string, string>();
        public MusicMessage()
        {
            base.postData["msgtype"] = "music";
            base.postData["music"] = music;
        }

        public void SetTitle(string title)
        {
            music["title"] = title;
        }
        public void SetMusicUrl(string musicUrl)
        {
            music["musicurl"] = musicUrl;
        }
        public void SetHQMusicUrl(string hq_MusicUrl)
        {
            music["hqmusicurl"] = hq_MusicUrl;
        }
        public void SetDescription(string description)
        {
            music["description"] = description;
        }
        public void SetThumbMediaId(string thumbMediaId)
        {
            music["thumb_media_id"] = thumbMediaId;
        }

    }
}
