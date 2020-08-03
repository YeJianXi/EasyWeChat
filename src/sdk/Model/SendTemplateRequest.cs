using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WeChat.Model
{
    public class TemplateDataFiled
    {

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Filed { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 参数值显示的颜色
        /// </summary>
        public Color Color { get; set; }

    }
    public class SendTemplateRequest
    {
        public SendTemplateRequest(string touser, string template_id)
        {
            root["touser"] = touser;
            root["template_id"] = template_id;
        }
        /// <summary>
        /// 序列化根对象
        /// </summary>
        Dictionary<string, object> root = new Dictionary<string, object>();

        public string touser
        {
            get
            {
                return root["touser"]?.ToString();
            }
        }

        public string template_id
        {
            get
            {
                return root["template_id"]?.ToString();
            }
        }

        public string Url
        {
            get
            {
                return root["url"]?.ToString();
            }
            set
            {
                root["url"] = value;
            }
        }

        public void SetMiniprogram(string appid, string pagepath)
        {
            Dictionary<string, object> miniprogramDic = root.GetValue<Dictionary<string, object>,string,object>("miniprogram");
            miniprogramDic["appid"] = appid;
            miniprogramDic["pagepath"] = pagepath;

        }

        public void SetData(params TemplateDataFiled[] fields)
        {
            if (fields == null || !fields.Any())
            {
                return;
            }
            Dictionary<string, object> dataDic = root.GetValue<Dictionary<string, object>, string, object>("data");
            foreach (var filed in fields)
            {
                dataDic[filed.Filed] = new
                {
                    value = filed.Value,
                    color = filed.Color.ToRGB()
                };
            }
        }

        internal string ToJson()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root);
            return json;
        }
    }


}
