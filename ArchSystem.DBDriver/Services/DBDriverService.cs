using ArchSystem.Dto.Models;
using DBDriver.Services;
using System.Data;
using System.Data.Common;

namespace ArchSystem.DBDriver.Services
{
    public interface IDBDriverService
    {
        Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto Output, IEnumerable<TOutputModel> OutputModel, IEnumerable<SpParamsDto> SpParams)> InvokeSp<TOutputModel>(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class;
        
        Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto Output, IEnumerable<SpParamsDto> SpParams)> InvokeSp(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null);

        Task<ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>> InvokeSpReturnsDataSet<TOutputModel>(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class;
    }

    public class DBDriverService: IDBDriverService 
    {

        public async Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto, IEnumerable<TOutputModel>, IEnumerable<SpParamsDto>)> InvokeSp<TOutputModel>(SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class
        {
            DBSource _dBSource;
            if (dbConnection != null)
                _dBSource = new DBSource
                {
                    ConnectionParams = dbConnection
                };
            else
            {
                var (outputDto, dBSource) = DBConnectionService.GetDBSource(spInfoDto.DataSourceKeyName);
                if (!outputDto.ErrorHandling.IsSuccessful)
                    return (new Dto.Models.DBDriverService.OutputDto { ErrorHandling = outputDto.ErrorHandling }, default, spParamsDto);
                _dBSource = dBSource;
            }
            var closeDbConnection = (dbConnection?.CloseDbConnection) ?? true;
            switch (_dBSource.DBEngine)
            {
                case Dto.Enums.DBEngine.MSSQLServer:
                    var dbEngineMSSQL = new MSSQLServerDapperService(_dBSource, dbConnection?.DBEngineLastConnection?.SqlConnection);
                    var result1 =await dbEngineMSSQL.InvokeSp<TOutputModel>(spInfoDto, spParamsDto);
                    if (closeDbConnection)
                        dbEngineMSSQL?.CloseConnection();

                    var lastConnectionSQL = dbEngineMSSQL?.GetConnection();
                    if (lastConnectionSQL != null)
                        result1.Output.DBEngineLastConnection = new DBEngineLastConnection { SqlConnection = lastConnectionSQL };
                    return result1;
                case Dto.Enums.DBEngine.MySql:
                    break;
                case Dto.Enums.DBEngine.Oracle:
                    break;
                default:
                    break;
            }
            return (new ArchSystem.Dto.Models.DBDriverService.OutputDto { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "The DBEngine is undefined" } }, default, null);
        }

        public async Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto, IEnumerable<SpParamsDto>)> InvokeSp(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null)
        {
            DBSource _dBSource;
            if (dbConnection != null && !string.IsNullOrWhiteSpace(dbConnection.DataSource))
                _dBSource = new DBSource
                {
                    ConnectionParams = dbConnection
                };
            else
            {
                var (outputDto, dBSource) = DBConnectionService.GetDBSource(spInfoDto.DataSourceKeyName);
                if (!outputDto.ErrorHandling.IsSuccessful)
                    return (new Dto.Models.DBDriverService.OutputDto { ErrorHandling = outputDto.ErrorHandling }, spParamsDto);
                _dBSource = dBSource;
            }
            var closeDbConnection = (dbConnection?.CloseDbConnection) ?? true;
            switch (_dBSource.DBEngine)
            {
                case Dto.Enums.DBEngine.MSSQLServer:
                    var dbEngineMSSQL = new MSSQLServerDapperService(_dBSource, dbConnection?.DBEngineLastConnection?.SqlConnection);

                    var result1 = await dbEngineMSSQL.InvokeSp(spInfoDto, spParamsDto);

                    if (closeDbConnection)
                        dbEngineMSSQL?.CloseConnection();

                    var lastConnectionSQL = dbEngineMSSQL?.GetConnection();
                    if (lastConnectionSQL != null)
                        result1.Output.DBEngineLastConnection = new DBEngineLastConnection { SqlConnection = lastConnectionSQL };
                    return result1;
                case Dto.Enums.DBEngine.MySql:
                    break;
                case Dto.Enums.DBEngine.Oracle:
                    break;
                default:
                    break;
            }
            return (new ArchSystem.Dto.Models.DBDriverService.OutputDto { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "The DBEngine is undefined" } }, null);
        }

        public async Task<Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>> InvokeSpReturnsDataSet<TOutputModel>(SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class
        {
            DBSource _dBSource;
            if (dbConnection != null && !string.IsNullOrWhiteSpace(dbConnection.DataSource))
                _dBSource = new DBSource
                {
                    ConnectionParams = dbConnection
                };
            else
            {
                var (outputDto, dBSource) = DBConnectionService.GetDBSource(spInfoDto.DataSourceKeyName);
                if (!outputDto.ErrorHandling.IsSuccessful)
                    return new ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>
                    {
                        ErrorHandling = outputDto.ErrorHandling
                    };
                _dBSource = dBSource;
            }
            var closeDbConnection = (dbConnection?.CloseDbConnection) ?? true;
            switch (_dBSource.DBEngine)
            {
                case Dto.Enums.DBEngine.MSSQLServer:
                    var dbEngineMSSQL = new MSSQLServerDapperService(_dBSource, dbConnection?.DBEngineLastConnection?.SqlConnection);
                    var result1 = await dbEngineMSSQL.InvokeSpReturnsDataSet<TOutputModel>(spInfoDto, spParamsDto);

                    if (closeDbConnection)
                        dbEngineMSSQL?.CloseConnection();

                    var lastConnectionSQL = dbEngineMSSQL?.GetConnection();
                    if (lastConnectionSQL != null)
                        result1.DBEngineLastConnection = new DBEngineLastConnection { SqlConnection = lastConnectionSQL };

                    return result1;
                case Dto.Enums.DBEngine.MySql:
                    break;
                case Dto.Enums.DBEngine.Oracle:
                    break;
                default:
                    break;
            }
            return new ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>> { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "The DBEngine is undefined" } };
        }
    }
}
