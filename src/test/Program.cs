using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using  Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace test
{
    class Program
    {
        static string accesToken;
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            GetAccessToken(client).Wait();
            GetTempQRCode(client).Wait();
        }

        static async Task GetAccessToken(HttpClient client)
        {
            // {"access_token":"35_Kfc59VZI3rio3gSU6R_m0WKiq0EtILksW5igwkT4s0sYKGttSjtABEjewV-Aj0ZIic7ijDjrOIqKxKY_6KjOp5lc6Wn1NPJJ5vXtGNarJivhf8IIy4PilEl1cV0BxCnl1enzBU_0AZPr4fQBQDFjACAVIK","expires_in":7200}
            string appId = "wx0fc4ee9e61fbabd6";
            string secret = "759081f722cdc7205b294db83b6b9937";
            string url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={secret}";
           var response =  await client.GetAsync(url);
           string json = await response.Content.ReadAsStringAsync();
           accesToken = JObject.Parse(json).Value<string>("access_token");
           Console.WriteLine(accesToken);
        }
        static async Task GetTempQRCode(HttpClient client)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={accesToken}";
            Dictionary<string,object> param = new Dictionary<string,object>();
            param["expire_seconds"] = 604800;
            param["action_name"] = "QR_STR_SCENE";
            param["action_info"] = new{
                scene = new{
                    scene_str = "test"

                }
            };

            HttpContent content  = new StringContent(JsonConvert.SerializeObject(param));
            var response =  await client.PostAsync(url,content);
            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);
        }
    }
}
