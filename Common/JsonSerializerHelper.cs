using System.Web.Script.Serialization;

namespace Common
{
    public class JsonSerializerHelper
    {
        public static string SerializerJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static T GetEntityForJson<T>(string strJson)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T objs = serializer.Deserialize<T>(strJson);
            return objs;
        }
    }
}
