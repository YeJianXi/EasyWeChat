using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class Templates
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 主行业
        /// </summary>
        public string primary_industry { get; set; }
        /// <summary>
        /// 从行业
        /// </summary>
        public string deputy_industry { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 例子
        /// </summary>
        public string example { get; set; }

     
    }
}
