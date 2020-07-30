using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sdk
{
    internal static class ExtendMethods
    {

        /// <summary>
        /// 取到Color的RGB转为16进制表示
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        internal static string ToRGB(this Color color)
        {
            var B = color.B.ToString("x2");
            var R = color.R.ToString("x2");
            var G = color.G.ToString("x2");
            return $"#{R}{G}{B}";
        }

        /// <summary>
        /// 将响应结果中的Body Json串进行序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        internal static async Task<T> GetAsync<T>(this HttpClient client, string requestUri) where T : class
        {
            var response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 将响应结果中的Body Json串进行序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        internal static async Task<T> PostAsync<T>(this HttpClient client, string requestUri, HttpContent content) where T : class
        {
            var response = await client.PostAsync(requestUri, content);
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
            else
            {
                return null;
            }

        }


        /// <summary>
        /// 安全取Dic里面的值,如果没有就New一个放到字典里
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static TReturn GetValue<TReturn, TKey, TVal>(this Dictionary<TKey, TVal> dic, TKey key)
            where TReturn : class, new()
            where TVal : class, new()
        {

            if (dic.TryGetValue(key, out TVal val))
            {
                return val as TReturn;
            }
            else
            {
                TReturn retun = new TReturn();
                dic[key] = retun as TVal;
                return retun;
            }

        }

    }
}
