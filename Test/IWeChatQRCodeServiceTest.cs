using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    using Microsoft.Extensions.DependencyInjection;
    using EasyWeChat.Interface;
    using EasyWeChat.Model;
    using System.Threading.Tasks;

    [TestClass]
    public class IWeChatQRCodeServiceTest:BaseTest
    {

        [TestMethod]
        public async Task  Test_GenerateTempQRCodeInt()
        {
            IWeChatQRCodeService weChatQRCodeService = _sp.GetService<IWeChatQRCodeService>();
            var request = new CreateTempQRIntSceneCodeRequest(3600);
            request.SetScene(520);
           var result = await  weChatQRCodeService.GenerateTempQRCode(await GetAccessToken(), request);
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.ticket));
         
        }
        [TestMethod]
        public async Task Test_GenerateTempQRCodeStr()
        {
            IWeChatQRCodeService weChatQRCodeService = _sp.GetService<IWeChatQRCodeService>();
            var request = new CreateTempQRStrSceneCodeRequest(3600);
            request.SetScene("520");
            var result = await weChatQRCodeService.GenerateTempQRCode(await GetAccessToken(), request);
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.ticket));

        }
        [TestMethod]
        public async Task Test_GetWXAcodeUnlimit()
        {
            IWeChatQRCodeService weChatQRCodeService = _sp.GetService<IWeChatQRCodeService>();
            var request = new GetWXAcodeUnlimitRequest();
            request.Scene = "520";
            request.Auto_color = true;
            request.Is_hyaline = true;
            var result = await weChatQRCodeService.GetWXAcodeUnlimit(await GetAccessToken(), request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ErrCode == 0);

        }
    }
}
