using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal static class HttpClientExtend
    {


        /// <summary>
        /// 将响应结果中的Body Json串进行序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        internal static async Task<T> GetAsync<T>(this HttpClient client
            , string requestUri
            ,ILogger logger) where T : class
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                var response = await client.GetAsync(requestUri);
                httpResponseMessage = response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                logger?.LogInformation(body);
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex,"");
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
        internal static async Task<T> PostAsync<T>(this HttpClient client
            , string requestUri
            , HttpContent content
            , ILogger logger) where T : class
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                var response = await client.PostAsync(requestUri, content);
                httpResponseMessage = response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                logger?.LogInformation(body);
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "");
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
        internal static async Task<string> PostAsync(this HttpClient client
            , string requestUri
            , HttpContent content
            , ILogger logger) 
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                var response = await client.PostAsync(requestUri, content);
                httpResponseMessage = response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                logger?.LogInformation(body);
                return body;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "");
                return null;
            }

        }


    }
}
