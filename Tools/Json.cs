using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace EventSockets.API.Tools
{
    public static class Json
    {

        public static byte[] Serialize(object o)
        {
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(o.GetType());
                var memoryStream = new MemoryStream();
                jsonSerializer.WriteObject(memoryStream, o);
                return memoryStream.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string Stringify(object o)
        {
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(o.GetType());
                var memoryStream = new MemoryStream();
                jsonSerializer.WriteObject(memoryStream, o);
                return UTF8Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(new MemoryStream(bytes, 0, bytes.Length));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static T Parse<T>(string s)
        {
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(s)));
            }
            catch (Exception)
            {
                return default(T);
            }

        }
    }
}
