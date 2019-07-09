using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Qiniu.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.Common
{
    public class AnotherJsonSerializer : IJsonSerializer
    {
        // 实现此接口的JSON序列化方法
        public string Serialize<T>(T obj) where T : new()
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
    public class AnotherJsonDeserializer : IJsonDeserializer
    {
        // 实现此接口的JSON反序列化方法
        public bool Deserialize<T>(string str, out T obj) where T : new()
        {
            obj = default(T);
            bool ok = true;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(str);
            }
            catch (System.Exception)
            {
                ok = false;
            }
            return ok;
        }
    }
}
