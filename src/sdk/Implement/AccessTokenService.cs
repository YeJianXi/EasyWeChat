using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyWeChat.Model;

namespace EasyWeChat.Implement
{
    using Interface;


    public class AccessTokenService:WeiXinApiBaseService, IAccessTokenService
    {
        ILogger _logger;
        public AccessTokenService(IHttpClientFactory clientFactory, ILogger<AccessTokenService> logger):base(clientFactory)
        {
            _logger = logger;
        }


        public async Task<GetAccessTokenResponse> GetToken(string appId, string secret)
        {
            // {"access_token":"35_Kfc59VZI3rio3gSU6R_m0WKiq0EtILksW5igwkT4s0sYKGttSjtABEjewV-Aj0ZIic7ijDjrOIqKxKY_6KjOp5lc6Wn1NPJJ5vXtGNarJivhf8IIy4PilEl1cV0BxCnl1enzBU_0AZPr4fQBQDFjACAVIK","expires_in":7200}

            string url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={secret}";
            GetAccessTokenResponse response = await this._client.GetAsync<GetAccessTokenResponse>(url, _logger);
            return response;
        }


        public async Task<GetTicketResponse> GetTicket(string accessToken)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";
            GetTicketResponse response = await this._client.GetAsync<GetTicketResponse>(url, _logger);
            return response;
        }



    }
}
