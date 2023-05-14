using ArchSystem.Dto.Models;
using Dapper;
using DBDriver.Interfaces;
using DBDriver.Services;
using System.Data;
using System.Data.SqlClient;
using ArchSystem.Core.Extensions;

namespace ArchSystem.DBDriver.Services
{
    public class MSSQLServerDapperService : IDapper
    {
        private SqlConnection Connection { get; set; }
        
        public IDBSource DBSource { get; }

        public MSSQLServerDapperService(DBSource dBSource, SqlConnection connection=null)
        {
            DBSource = dBSource;
            Connection = connection;
        }
        public SqlConnection GetConnection() {
            return Connection !=null && Connection.State == ConnectionState.Open ? Connection : null;
        }

        private void SetConnection()
        {
            var connectionString =
                    $@"Server={DBSource.ConnectionParams.DataSource};
                        Database={DBSource.ConnectionParams.CatalogName};
                        User Id={DBSource.ConnectionParams.Username}; 
                        Password={DBSource.ConnectionParams.Password};
                        MultipleActiveResultSets=true;
                        Pooling=false;";
            Connection = new SqlConnection(connectionString);
        }

        public async void CloseConnection()
        {
            try
            {
                await Connection.CloseAsync();
                await Connection.DisposeAsync();
            }
            catch { }
            Connection = null;
        }
        
        public async Task<(Dto.Models.DBDriverService.OutputDto Output, IEnumerable<TOutputModel> OutputModel, IEnumerable<SpParamsDto> SpParams)> InvokeSp<TOutputModel>(
            SpInfoDto spInfoDto, 
            IEnumerable<SpParamsDto> spParamsDto = null) where TOutputModel:class
        {
            var procedureName = (string.IsNullOrWhiteSpace(spInfoDto.SchemaName) ? "" : $"{spInfoDto.SchemaName}.") + spInfoDto.ProcedureName;
            IEnumerable<TOutputModel> resultSp = null;
            try
            {
                if (DBSource is null)
                {
                    var errorMessage = "Your DBSource is undefined.";
                    return (new ArchSystem.Dto.Models.DBDriverService.OutputDto
                    {
                        ErrorHandling = new ErrorHandlingDto
                        {
                            ErrorCode = 1,
                            ErrorMessage = errorMessage
                        }
                    }, default, spParamsDto);
                }

                var param = new DynamicParameters();

                if (!(spParamsDto is null))
                    foreach (var item in spParamsDto)
                    {
                        param.Add(item.FieldName, item.InputValue, item.DataType, item.ParameterDirection,item.Size);
                    }

                if (Connection is null || Connection.State == ConnectionState.Closed)
                {
                    SetConnection();
                    await Connection.OpenAsync();
                }

                resultSp = await Connection.QueryAsync<TOutputModel>(procedureName, param, commandType: CommandType.StoredProcedure);               

                if (!(spParamsDto is null))
                    foreach (var item in spParamsDto)
                    {
                        if (item.ParameterDirection == ParameterDirection.Output ||
                            item.ParameterDirection == ParameterDirection.InputOutput)
                            item.OutputValue = param.Get<object>(item.FieldName);
                    }
                if (DBSource.ProfilerIsActive)
                {
                    var (outputDto, commandAndResponse, isErrorMarkNeeded) = DBConnectionService.GetExecutedSpCommandAndResponse(spInfoDto: spInfoDto, spParamsDto: spParamsDto, data: resultSp);
                }
                return (new Dto.Models.DBDriverService.OutputDto(), resultSp, spParamsDto);
            }
            catch (Exception ex)
            {               
                var res = new ArchSystem.Dto.Models.DBDriverService.OutputDto
                {
                    ErrorHandling = new ErrorHandlingDto()
                };
                res.ErrorHandling.ErrorCode = -1;
                res.ErrorHandling.ErrorMessage = "An error has occured.";
                res.ErrorHandling.ErrorTechnicalMessage = ex.FullMessage();

                if (DBSource.ProfilerIsActive)
                {
                    var (baseResultDto, commandAndResponse, isErrorMarkNeeded) = DBConnectionService.GetExecutedSpCommandAndResponse(spInfoDto: spInfoDto, spParamsDto: spParamsDto, data: resultSp);
                }
                return (res, default, spParamsDto);
            }
        }

        public async Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto Output, IEnumerable<SpParamsDto> SpParams)> InvokeSp(
           SpInfoDto spInfoDto,
           IEnumerable<SpParamsDto> spParamsDto = null)
        {
            var procedureName = (string.IsNullOrWhiteSpace(spInfoDto.SchemaName) ? "" : $"{spInfoDto.SchemaName}.") + spInfoDto.ProcedureName;
            try
            {
                if (DBSource is null)
                {
                    var errorMessage = "Your DBSource is undefined.";
                    return (new ArchSystem.Dto.Models.DBDriverService.OutputDto
                    {
                        ErrorHandling = new ErrorHandlingDto
                        {
                            ErrorCode = 1,
                            ErrorMessage = errorMessage
                        }
                    }, spParamsDto);
                }
                var param = new DynamicParameters();
                if (!(spParamsDto is null))
                    foreach (var item in spParamsDto)
                    {
                        param.Add(item.FieldName, item.InputValue, item.DataType, item.ParameterDirection, item.Size);
                    }

                if (Connection is null || Connection.State == ConnectionState.Closed)
                {
                    SetConnection();
                    await Connection.OpenAsync();
                }

                await Connection.ExecuteAsync(procedureName, param, commandType: CommandType.StoredProcedure);

                if (!(spParamsDto is null))
                    foreach (var item in spParamsDto)
                    {
                        if (item.ParameterDirection == ParameterDirection.Output ||
                            item.ParameterDirection == ParameterDirection.InputOutput)
                            item.OutputValue = param.Get<object>(item.FieldName);
                    }
                return (new ArchSystem.Dto.Models.DBDriverService.OutputDto(), spParamsDto);
            }
            catch (Exception ex)
            {
                var res = new ArchSystem.Dto.Models.DBDriverService.OutputDto
                {
                    ErrorHandling = new ErrorHandlingDto()
                };
                res.ErrorHandling.ErrorCode = -1;
                res.ErrorHandling.ErrorMessage = "An error has occured.";
                res.ErrorHandling.ErrorTechnicalMessage = ex.FullMessage();
                return (res, spParamsDto);
            }
        }

        public async Task<ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>> InvokeSpReturnsDataSet<TOutputModel>(SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null) where TOutputModel : class
        {
            try
            {
                var procedureName = (string.IsNullOrWhiteSpace(spInfoDto.SchemaName) ? "" : $"{spInfoDto.SchemaName}.") + spInfoDto.ProcedureName;
                if (DBSource is null)
                {
                    var errorMessage = "Your DBSource is undefined.";
                    return new ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>
                    {
                        ErrorHandling = new ErrorHandlingDto
                        {
                            ErrorCode = 1,
                            ErrorMessage = errorMessage
                        }
                    };
                }

                var param = new DynamicParameters();
                if (!(spParamsDto is null))
                    foreach (var item in spParamsDto)
                    {
                        param.Add(item.FieldName, item.InputValue, item.DataType, item.ParameterDirection, item.Size);
                    }

                if (Connection is null || Connection.State == ConnectionState.Closed)
                {
                    SetConnection();
                    await Connection.OpenAsync();
                }
                var result = await Connection.QueryAsync<TOutputModel>(procedureName, param, commandType: CommandType.StoredProcedure);

                return new ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>()
                {
                    ErrorHandling = new ErrorHandlingDto(),
                    Data = result
                };
            }
            catch (Exception ex)
            {
                var res = new ArchSystem.Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>
                {
                    ErrorHandling = new ErrorHandlingDto()
                };

                res.ErrorHandling.ErrorCode = -1;
                res.ErrorHandling.ErrorMessage = "An error has occured.";
                res.ErrorHandling.ErrorTechnicalMessage = ex.FullMessage();
                return res;
            }
        }
    }
}