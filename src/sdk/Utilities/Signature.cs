using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EasyWeChat.Model;

namespace EasyWeChat.Utilities
{
    public class Signature
    {
        public static bool ServerValidate(ServerValidateParams param)
        {

            string[] arr = new string[3] { param.token, param.timestamp, param.nonce };
            Array.Sort(arr);
            SHA1 sha1 = SHA1.Create();
                byte[] sha1str = sha1.ComputeHash(Encoding.UTF8.GetBytes(string.Join("", arr)));
                StringBuilder sb = new StringBuilder();
                foreach (var item in sha1str)
                {
                    sb.Append(item.ToString("x2"));
                }

                if (sb.ToString().Equals(param.signature, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }

        }
    }
}
