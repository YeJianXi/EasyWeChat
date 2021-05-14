using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{

   public  class VoiceMessage: CustomMessage
    {

        IDictionary<string, string> voice = new Dictionary<string, string>();
        public VoiceMessage()
        {
            base.postData.Add("msgtype", "voice");
            base.postData.Add("voice", voice);
        }
        public void SetMediaId(string mediaId)
        {
            voice["media_id"] = mediaId;
        }
    }
}
