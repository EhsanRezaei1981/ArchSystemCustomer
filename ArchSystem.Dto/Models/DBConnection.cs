using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ArchSystem.Dto.Models
{
    public interface IDBConnection
    {
        Dto.Enums.Environment? Environment { get; set; }
        string CatalogName { get; set; }
        string DataSource { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        uint? Port { get; set; }
        uint? ConnectionTimeout { get; set; }
        uint? CommandTimeout { get; set; }
        uint? MaxPoolSize { get; set; }
        bool Compress { get; set; }
        bool Pooling { get; set; }
        bool CloseDbConnection { get; set; } 
        DBEngineLastConnection DBEngineLastConnection { get; set; }
    }

    public class DBConnection: IDBConnection
    {
        public Dto.Enums.Environment? Environment { get; set; }
        public string CatalogName { get; set; }
        public string DataSource { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public uint? Port { get; set; }
        public uint? ConnectionTimeout { get; set; }
        public uint? CommandTimeout { get; set; }
        public uint? MaxPoolSize { get; set; }
        public bool Compress { get; set; }
        public bool Pooling { get; set; }
        public bool CloseDbConnection { get; set; } = true;
        [JsonIgnore]
        public DBEngineLastConnection DBEngineLastConnection { get; set; }
    }
    public sealed class DBEngineLastConnection
    {
        [JsonIgnore]
        public SqlConnection SqlConnection { get; set; }
        [JsonIgnore]
        public MySqlConnection MySqlConnection { get; set; }
    }
}
