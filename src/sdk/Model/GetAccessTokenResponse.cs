using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class GetAccessTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }

    }
}
