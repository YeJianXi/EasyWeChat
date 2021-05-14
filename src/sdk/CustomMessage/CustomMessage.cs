using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{

    /// <summary>
    /// 客服消息基类
    /// </summary>
   public abstract  class CustomMessage
    {

        protected IDictionary<string, object> postData = new Dictionary<string, object>();

        public void SetToUser(string toUser)
        {
            postData.Add("touser", toUser);
        }

        public string ToJson()
        {
            string data = JsonConvert.SerializeObject(this.postData);
            return data;
        }
    }


}
