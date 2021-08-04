using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EasyWeChat.Model;

namespace EasyWeChat.Interface
{
    public interface IWeChatQRCodeService
    {

        /// <summary>
        /// 生成临时二维码
        /// </summary>
        /// <typeparam name="TSceneType"></typeparam>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateQRCodeResponse> GenerateTempQRCode<TSceneType>(string accessToken, CreateTempQRCodeRequest<TSceneType> request);
        
        /// <summary>
        /// 生成永久二维码
        /// </summary>
        /// <typeparam name="TSceneType"></typeparam>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateQRCodeResponse> GenerateLimitQRCode<TSceneType>(string accessToken, CreateLimitQRCodeRequest<TSceneType> request);

        Task<GetWXAcodeUnlimitResult> GetWXAcodeUnlimit(string accessToken,GetWXAcodeUnlimitRequest request);

    }
}
