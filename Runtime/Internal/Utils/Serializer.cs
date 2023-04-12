using System.Globalization;
using Newtonsoft.Json;

namespace OpenAIToolkit
{
    public static class Serializer
    {
        private static readonly JsonSerializerSettings Settings;

        static Serializer()
        {
            Settings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                Culture = CultureInfo.InvariantCulture
            };
        }

        public static string ToJson<T>(T data)
        {
            return JsonConvert.SerializeObject(data, Settings);
        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }
    }
}