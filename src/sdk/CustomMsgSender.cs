using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeChat
{
    public abstract class CustomMsgSender
    {

        protected IDictionary<string, object> postData = new Dictionary<string, object>();
        public virtual async Task<bool> Send(string token,string touser)
        {
            postData.Add("touser", touser);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $@"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={token}";
                    string data = JsonConvert.SerializeObject(this.postData);
                    HttpContent content = new StringContent(data);
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    var jobj = JObject.Parse(result);
                    if (jobj.TryGetValue("errcode", out JToken value))
                    {
                        int errcode = value.Value<int>();
                        return errcode == 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }

    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextCustomMsgSender : CustomMsgSender {

        public string content { get; set; }

        public TextCustomMsgSender()
        {
            base.postData.Add("msgtype", "text");
        }

        public override Task<bool> Send(string token, string touser)
        {
            this.postData.Add("text", new
            {
                content = this.content
            });
            return base.Send(token, touser);
        }

    }


    /// <summary>
    /// 自定义的图文消息
    /// </summary>
    public class NewsCustomMsgSender : CustomMsgSender
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string  Url { get; set; }

        public string  PicUrl { get; set; }

        public NewsCustomMsgSender()
        {
            base.postData.Add("msgtype", "news");
        }

        public override Task<bool> Send(string token, string touser)
        {
            Dictionary<string, object> news = new Dictionary<string, object>();
            Dictionary<string, object>[] articles = new Dictionary<string, object>[1];
            articles[0] = new Dictionary<string, object>();
            articles[0].Add("title", Title);
            articles[0].Add("description", Description);
            articles[0].Add("url", "https://m.sxkid.com" + "/jump?url=" + Uri.EscapeDataString(this.Url));
            articles[0].Add("picurl",PicUrl);
            news.Add("articles", articles);
            this.postData.Add("news", news);
            return base.Send(token, touser);
        }

    }

    /// <summary>
    /// 自定义小程序消息
    /// </summary>
    public class MiniProgramCustomMsgSender : CustomMsgSender
    {

        public string Title { get; set; }
        public string Appid { get; set; }
        public string Pagepath { get; set; }
        public string ThumbMediaId { get; set; }

        public MiniProgramCustomMsgSender()
        {
            base.postData.Add("msgtype", "miniprogrampage");
        }

        public override Task<bool> Send(string token, string touser)
        {
            Dictionary<string, object> miniprogrampage = new Dictionary<string, object>
            {
                { "title", Title },
                { "appid", Appid },
                { "pagepath", Pagepath },
                { "thumb_media_id", ThumbMediaId }
            };
            this.postData.Add("miniprogrampage", miniprogrampage);
            return base.Send(token, touser);
        }

    }



}
