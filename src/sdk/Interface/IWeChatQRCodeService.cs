using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WeChat.Model;

namespace WeChat.Interface
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



        Task<GetWXAcodeUnlimitResult> GetWXAcodeUnlimit(string accessToken,GetWXAcodeUnlimitRequest request);

    }
}
