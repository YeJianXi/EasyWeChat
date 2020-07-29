using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace web.Controllers
{

    public class ReciveController : ControllerBase
    {
        string token = "93C8F33F-A90B-4A91-ABBC-855B7C8F9A97";

        [Route("[controller]")]
        public IActionResult Recive()
        {
            string signature = Request.Query["signature"].ToString();
            string timestamp = Request.Query["timestamp"].ToString();
            string nonce = Request.Query["nonce"].ToString(); ;
            string echostr = Request.Query["echostr"].ToString();
            string[] arr = new string[3] {token,timestamp,nonce };
             Array.Sort(arr);
            if (CheckSignature(string.Join("",arr), signature))
            {
                return Content(echostr);
            }
            else
            {
                return Content("校验错误");
            }

        }

        bool CheckSignature(string param, string signature)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] sha1str = sha1.ComputeHash(Encoding.UTF8.GetBytes(param));
            StringBuilder sb = new StringBuilder();
            foreach (var item in sha1str)
            {
                sb.Append(item.ToString("x2"));
            }
   
            if (sb.ToString().Equals(signature, StringComparison.CurrentCultureIgnoreCase))
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