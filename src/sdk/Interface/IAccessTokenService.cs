using EasyWeChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeChat.Interface
{
   public  interface IAccessTokenService
    {

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
         Task<GetAccessTokenResponse> GetToken(string appId, string secret);


        /// <summary>
        /// 获取jsapi凭据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
       Task<GetTicketResponse> GetTicket(string accessToken)
    }
}
