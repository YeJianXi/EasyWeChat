using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using test;
using WeChat;
using WeChat.Model;
using System.Drawing;

namespace test
{
    class Program
    {

        static readonly string appId = "wx0fc4ee9e61fbabd6";
        static readonly string secret = "759081f722cdc7205b294db83b6b9937";
        static string accessToken;
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            AccessTokenManager accessTokenManager = new AccessTokenManager(client, appId, secret);
             accessTokenManager.StartTimingGetToken((output) =>
            {
                Console.WriteLine(output.AccessToken);
                Console.WriteLine(output.JSAPITicket);
            },60*10);
            Color color = "#ff0000".ToColor();
            Console.ReadKey();
        }

        static void LongUriToShortUriTest(HttpClient client)
        {
            AccountManager accountManager = new AccountManager(client);
            var request = new CreateTempQRStrSceneCodeRequest();
            request.SetScene("oneguiidsdjfkldsj");
            var response = accountManager.LongUriToShortUri("http://www.baidu.com", accessToken).GetAwaiter().GetResult();
        }


        static void GetTempQRCodeTest(HttpClient client)
        {
            AccountManager accountManager = new AccountManager(client);
            var request = new CreateTempQRStrSceneCodeRequest();
            request.SetScene("oneguiidsdjfkldsj");
            var response = accountManager.GetTempQRCode(accessToken, request).GetAwaiter().GetResult();
        }

        static void DeleteTemplateTest(HttpClient client)
        {
            TemplateManager templateManager = new TemplateManager(client);
            TemplateListResponse templates = templateManager.GetTemplates(accessToken).GetAwaiter().GetResult();
            bool del = templateManager.DeleteTemplate(accessToken, "").GetAwaiter().GetResult();

        }

        static void SendTemplateTest(HttpClient client)
        {
            TemplateManager templateManager = new TemplateManager(client);
            SendTemplateRequest sendTemplateRequest = new SendTemplateRequest("ozS7j1XjseWWqzDkodixV3WvLWAY", "DN_bgsKpQVkKS45FbRDnm8ke6oqMTbLsxBjtJ07xCEs");
            sendTemplateRequest.Url = "https://www.baidu.com";
            sendTemplateRequest.SetData(new TemplateDataFiled[] {
                 new TemplateDataFiled(){
                  Filed = "circle",
                   Value = "超级无敌粉丝圈",
                    Color =  Color.Red
                 }
            });
            SendTemplateResponse response = templateManager.SendAsync(accessToken, sendTemplateRequest).GetAwaiter().GetResult();


        }

        public void HashTest()
        {
            SHA1 sha1 = SHA1.Create();
            byte[] sha1str = sha1.ComputeHash(Encoding.Default.GetBytes("abfdasfsafc"));//160位
            SHA256 sha256 = SHA256.Create();
            byte[] sha256str = sha256.ComputeHash(Encoding.Default.GetBytes("abfdasfsafc"));//256位
            MD5 md5 = MD5.Create();
            byte[] md5str = md5.ComputeHash(Encoding.Default.GetBytes("abfdasfsafc"));//128位
            HMAC hmacmd5 = new HMACMD5();
            byte[] hmacmd5str = hmacmd5.ComputeHash(Encoding.Default.GetBytes("abfdasfsafc"));//128位
            HMAC hmacmd5k = new HMACMD5(Encoding.Default.GetBytes("happy"));
            byte[] hmacmd5kstr = hmacmd5k.ComputeHash(Encoding.Default.GetBytes("abfdasfsafc"));//

            string tmp = 12.ToString("x2");
        }


    }
}
