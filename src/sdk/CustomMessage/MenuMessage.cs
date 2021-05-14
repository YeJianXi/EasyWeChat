using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.CustomMessage
{

   public  class MenuMessage : CustomMessage
    {

        IDictionary<string, object> msgmenu = new Dictionary<string, object>();
        public MenuMessage()
        {
            base.postData.Add("msgtype", "msgmenu");
            base.postData.Add("msgmenu", msgmenu);
            msgmenu["list"] = new List<IDictionary<string, string>>();
        }
        public void SetHeadContent(string headContent)
        {
            msgmenu["head_content"] = headContent;
        }
        public void AddMenu(string id,string content)
        {
           var menuLst =  msgmenu["list"] as List<IDictionary<string, string>>;
            Dictionary<string, string> menu = new Dictionary<string, string>();
            menu["id"] = id;
            menu["content"] = content;
            menuLst.Add(menu);
        }
        public void SetTailContent(string tailContent)
        {
            msgmenu["tail_content"] = tailContent;
        }

    }
}
