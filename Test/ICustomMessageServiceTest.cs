using EasyWeChat.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EasyWeChat.CustomMessage;

namespace Test
{
    [TestClass]
    public class ICustomMessageServiceTest:BaseTest
    {
        [TestMethod]
        public async Task Test_SendTextMessageAsync()
        {
            ICustomMessageService customMessageService = _sp.GetService<ICustomMessageService>();
            TextMessage textMessage = new TextMessage();
            textMessage.SetContent("Hello World!");
            var token = await base.GetAccessToken();
            var result = await customMessageService.SendAsync(token, "ozS7j1XjseWWqzDkodixV3WvLWAY",textMessage);
            Assert.IsTrue(result.IsSuccess);

        }

        [TestMethod]
        public async Task Test_SendMenuMessageAsync()
        {
            ICustomMessageService customMessageService = _sp.GetService<ICustomMessageService>();
            MenuMessage message = new  MenuMessage();
            message.SetHeadContent("Hello World!");
            message.SetTailContent("打招呼！");
            message.AddMenu("1001", "取消");
            message.AddMenu("1002", "确认");
            var token = await base.GetAccessToken();
            var result = await customMessageService.SendAsync(token, "ozS7j1XjseWWqzDkodixV3WvLWAY", message);
            Assert.IsTrue(result.IsSuccess);

        }


        [TestMethod]
        public async Task Test_SendNewsMessageAsync()
        {
            ICustomMessageService customMessageService = _sp.GetService<ICustomMessageService>();
            NewsMessage message = new NewsMessage();
            message.SetTitle("你好");
            message.SetDescription("大家好，才是真的好。");
            message.SetUrl("m.sxkid.com");
            message.SetPicUrl("https://cos.sxkid.com/v4source/pc/imgs/home/sxb.png");
            var token = await base.GetAccessToken();
            var result = await customMessageService.SendAsync(token, "ozS7j1XjseWWqzDkodixV3WvLWAY", message);
            Assert.IsTrue(result.IsSuccess);

        }

    }
}
