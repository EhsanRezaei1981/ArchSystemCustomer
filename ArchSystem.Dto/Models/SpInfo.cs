using System.Data;

namespace ArchSystem.Dto.Models
{
    public interface ISpInfoDto
    {
        string ProcedureName { get; set; }
        string SchemaName { get; set; }
        string DataSourceKeyName { get; set; }
    }

    public class SpInfoDto: ISpInfoDto
    {
        public string ProcedureName { get; set; }
        public string SchemaName { get; set; }
        public string DataSourceKeyName { get; set; }
    }

    public interface ISpParamsDto
    {
        string FieldName { get; set; }
        object InputValue { get; set; }
        object OutputValue { get; set; }
        DbType DataType { get; set; }
        ParameterDirection ParameterDirection { get; set; }
        Int32 Size { get; set; }
    }
    public class SpParamsDto : ISpParamsDto
    {
        public string FieldName { get; set; }
        public object InputValue { get; set; }
        public object OutputValue { get; set; }
        public DbType DataType { get; set; } = DbType.String;
        public ParameterDirection ParameterDirection { get; set; } = ParameterDirection.Input;
        public Int32 Size { get; set; } = Int32.MaxValue;
    }
}
