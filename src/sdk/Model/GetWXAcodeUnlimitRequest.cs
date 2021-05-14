using System;
using System.Collections.Generic;
using System.Text;

namespace WeChat.Model
{
    public class GetWXAcodeUnlimitRequest
    {
        public string Scene { get; set; }

        public string Page { get; set; }

        public int Width { get; set; }

        public bool Auto_color { get; set; }

        public object Line_color { get; set; }

        public bool Is_hyaline { get; set; }
    }
}
