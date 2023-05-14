using Newtonsoft.Json;
using System.Data;
using System.Text.RegularExpressions;

namespace ArchSystem.Core.Converter
{
    public static class Json
    {
        public static string ObjectToJsonString<TModel>(TModel iModel)
        {
            if (iModel == null) return null;
            return Newtonsoft.Json.JsonConvert.SerializeObject(iModel, Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore                    
                });
        }

        public static TModel JsonToModel<TModel>(string json)
        {
            var typeTOutput = typeof(TModel);
            return string.IsNullOrWhiteSpace(json)
                ? default(TModel)
                : typeTOutput == typeof(string)
                    ? (TModel)Convert.ChangeType(json, typeof(TModel))
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(json);
        }        

        public static object JsonStringToJsonObject(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? null : Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(object));
            }
            catch { return null; }
        }
        
    }
}
