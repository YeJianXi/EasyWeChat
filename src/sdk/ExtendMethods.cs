using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sdk
{
    internal static class ExtendMethods
    {

        /// <summary>
        /// 将响应结果中的Body Json串进行序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        internal static async Task<T> GetJson<T>(this HttpClient client, string requestUri) where T : class
        {
            var response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
            else {
                return null;
            }

        }
    }
}
