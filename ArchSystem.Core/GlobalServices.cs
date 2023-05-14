using Newtonsoft.Json.Linq;

namespace ArchSystem.Core.Services
{
    public class GlobalServices
    {
        public static string GetObjectProperty(object obj, string propertyName)
        {
            try
            {
                if (obj is null) return null;
                var objString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                JObject jObject = JObject.Parse(objString);
                return jObject.SelectToken(propertyName)?.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
