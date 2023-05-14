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

        public static object ObjectToJsonObject<TModel>(TModel iModel)
        {
            return iModel == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject(ObjectToJsonString(iModel));
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
        public static TModel ObjectToModel<TModel>(object obj)
        {
            return JsonToModel<TModel>(ObjectToJsonString(obj));
        }

        public static List<TModel> JsonToListOfModel<TModel>(string json)
        {
            var typeTOutput = typeof(TModel);
            return string.IsNullOrWhiteSpace(json)
                ? new List<TModel>()
                : typeTOutput == typeof(string)
                    ? (List<TModel>)Convert.ChangeType(json, typeof(List<TModel>))
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<List<TModel>>(json);
        }

        public static object JsonStringToJsonObject(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? null : Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(object));
            }
            catch { return null; }
        }
        public static string Minify(string json) {
            if (string.IsNullOrWhiteSpace(json)) return json;
            return Regex.Replace(json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
        }
        public static (List<string>,List<DataTable>) DataTableToJson(DataTable table, int? packageRecordCount = null, bool removeNullValue = false)
        {
            if (table is null || table.Rows.Count == 0)
                return (null,null);

            if (packageRecordCount is null || packageRecordCount == 0)
            {
                return (new List<string> {
                    JsonConvert.SerializeObject(table,Newtonsoft.Json.Formatting.None,new JsonSerializerSettings{
                         NullValueHandling = removeNullValue ? NullValueHandling.Ignore : NullValueHandling.Include,
                        DefaultValueHandling=removeNullValue?DefaultValueHandling.Ignore:DefaultValueHandling.Include
                    })
                }, new List<DataTable> { table });
            }

            var result = new List<string>();
            var resultDataTable = new List<DataTable>();
            var dt = new DataTable();

            for (var i = 0; i < table.Columns.Count; i++)
            {
                dt.Columns.Add(table.Columns[i].ColumnName);
            }
            var index = 0;
            for (var i = 0; i < table.Rows.Count; i++)
            {
                dt.Rows.Add(table.Rows[i].ItemArray);
                index++;
                if (packageRecordCount == index)
                {
                    result.Add(JsonConvert.SerializeObject(dt, new JsonSerializerSettings
                    {
                        NullValueHandling = removeNullValue ? NullValueHandling.Ignore : NullValueHandling.Include,
                        DefaultValueHandling = removeNullValue ? DefaultValueHandling.Ignore : DefaultValueHandling.Include
                    }));
                    resultDataTable.Add(dt.Copy());
                    dt.Rows.Clear();
                    index = 0;
                }
            }

            if (dt.Rows.Count > 0)
            {
                result.Add(JsonConvert.SerializeObject(dt, new JsonSerializerSettings
                {
                    NullValueHandling = removeNullValue ? NullValueHandling.Ignore : NullValueHandling.Include,
                    DefaultValueHandling = removeNullValue ? DefaultValueHandling.Ignore : DefaultValueHandling.Include
                }));
                resultDataTable.Add(dt.Copy());
            }

            return (result, resultDataTable);

        }
    }
}
