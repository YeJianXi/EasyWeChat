using System;
using System.Collections.Generic;
using System.Text;

namespace sdk.Model
{
    /// <summary>
    /// 临时二维码请求参数
    /// </summary>
    public abstract class CreateTempQRCodeRequest<T>
    {
        protected Dictionary<string, object> root = new Dictionary<string, object>();

        public CreateTempQRCodeRequest(int expire_seconds = 30)
        {
            if (expire_seconds > 2592000)
            {
                throw new Exception("临时二维码有效期不能超过2592000秒,即30天");
            }
            root["expire_seconds"] = expire_seconds;
            root["action_name"] = "QR_SCENE";

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
    public class CreateTempQRStrSceneCodeRequest : CreateTempQRCodeRequest<string>
    {
        public CreateTempQRStrSceneCodeRequest(int expire_seconds = 30) : base(expire_seconds)
        {
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
    public class CreateTempQRIntSceneCodeRequest : CreateTempQRCodeRequest<int>
    {
        public CreateTempQRIntSceneCodeRequest(int expire_seconds = 30) : base(expire_seconds)
        {
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
