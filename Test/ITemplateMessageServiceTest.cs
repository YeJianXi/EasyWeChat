using EasyWeChat.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    [TestClass]
    public class ITemplateMessageServiceTest: BaseTest
    {
        [TestMethod]
        public async Task Test_GetTemplates()
        {
            ITemplateMessageService templateMessageService = _sp.GetService<ITemplateMessageService>();
            var token = await base.GetAccessToken();
            var templates = await templateMessageService.GetTemplates(token);
            Assert.IsNotNull(templates);

        }

    }
}
