using System;
using System.IO;
using System.Xml.Serialization;

namespace Common
{
    public class XmlSerializerHelper
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static T GetEntityFromXml<T>(string strXml)
        {
            T entity;
            using (var strReader = new StringReader(strXml))
            {
                //声明序列化对象实例serializer 
                var serializer = new XmlSerializer(typeof(T));
                //反序列化，并将反序列化结果值赋给变量i
                entity = (T)serializer.Deserialize(strReader);
            }

            return entity;
        }

        /// 序列化
        /// 
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            var stream = new MemoryStream();
            var xml = new XmlSerializer(type);
            //序列化对象
            xml.Serialize(stream, obj);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var str = sr.ReadToEnd();

            sr.Dispose();
            stream.Dispose();

            return str;
        }
    }
}
