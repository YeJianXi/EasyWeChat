using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using WeChat.Utilities;
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
            if (Signature.ServerValidate(new WeChat.Model.ServerValidateParams()
            {
                echostr = echostr,
                signature = signature,
                nonce = nonce,
                timestamp = timestamp,
                token = token
            })
            )
            {
                return Content(echostr);
            }
            else
            {
                return Content("校验错误");
            }

        }

    }
}