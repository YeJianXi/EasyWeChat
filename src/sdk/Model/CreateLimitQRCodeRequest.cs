using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    /// <summary>
    /// 临时二维码请求参数
    /// </summary>
    public abstract class CreateLimitQRCodeRequest<T>
    {
        protected Dictionary<string, object> root = new Dictionary<string, object>();

        public CreateLimitQRCodeRequest()
        {
            root["action_name"] = "QR_LIMIT_SCENE";

        }
        /// <summary>
        /// 设置场景值
        /// </summary>
        /// <param name="scenevalue"></param>
        public abstract void SetScene(T scenevalue);

        internal string ToJson()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root);
            return json;
        }
    }
    /// <summary>
    /// 场景值为string类型临时二维码请求参数
    /// </summary>
    public class CreateLimitQRStrCodeRequest : CreateLimitQRCodeRequest<string>
    {
        public CreateLimitQRStrCodeRequest() : base()
        {
            root["action_name"] = "QR_LIMIT_STR_SCENE";
        }


        public override void SetScene(string scenevalue)
        {
            if (scenevalue == null || scenevalue.Length < 1 || scenevalue.Length > 64) {
                throw new Exception("无效scenevalue值");
            }
            var action_infoDic = new Dictionary<string, object>();
            action_infoDic["scene"] = new
            {
                scene_str = scenevalue
            };
            root["action_info"] = action_infoDic;
        }
    }

    /// <summary>
    /// 场景值为int类型临时二维码请求参数
    /// </summary>
    public class CreateLimitQRIntCodeRequest : CreateLimitQRCodeRequest<int>
    {
        public CreateLimitQRIntCodeRequest() : base()
        {
            root["action_name"] = "QR_LIMIT_SCENE";
        }


        public override void SetScene(int scenevalue)
        {
            var action_infoDic = new Dictionary<string, object>();
            action_infoDic["scene"] = new
            {
                scene_id = scenevalue
            };
            root["action_info"] = action_infoDic;
        }
    }
}
