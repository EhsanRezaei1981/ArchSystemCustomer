using ArchSystem.Dto.Enums;
namespace ArchSystem.Dto.Models
{
    public interface IDBSource
    {
        public string DataSourceKeyName { get; set; }
        public bool ProfilerIsActive { get; set; }
        public DBConnection ConnectionParams { get; set; }
        public DBEngine DBEngine { get; set; } 
    }
    public class DBSource: IDBSource
    {
        public string DataSourceKeyName { get; set; }
        public bool ProfilerIsActive { get; set; }
        public DBConnection ConnectionParams { get; set; }
        public DBEngine DBEngine { get; set; } = DBEngine.MSSQLServer;
    }

    public sealed class _DBSource
    {
        public string DataSourceKeyName { get; set; }
        public bool ProfilerIsActive { get; set; }
        public List<DBConnection> ConnectionParams { get; set; }
        public DBEngine DBEngine { get; set; } = DBEngine.MSSQLServer;
    }

    public class DBSources
    {
        public IEnumerable<DBSource> DatabaseSources { get; set; }
    }

    public sealed class _DBSources
    {
        public IEnumerable<_DBSource> DatabaseSources { get; set; }
    }
}
