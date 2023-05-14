using ArchSystem.Dto.Models;
using Newtonsoft.Json;
using System.Text;
using ArchSystem.Core.Extensions;
namespace DBDriver.Services
{
    public static class DBConnectionService
    {
        public static (OutputDto Output, DBSource DBSource) GetDBSource(string dataSourceKeyName)
        {
            dataSourceKeyName ??= "ArchSystem";
            var appStartPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = new OutputDto
            {
                ErrorHandling = new ErrorHandlingDto()
            };
            const string settingDirectoryName = "Settings";
            const string settingFilename = "DB.Settings.json";
            _DBSource _dBSource = null;
            try
            {
                string fileFullPath = $"{appStartPath}/{settingDirectoryName}/{settingFilename}";
                if (File.Exists(fileFullPath))
                {
                    var settingFileContent = File.ReadAllText(fileFullPath);
                    _dBSource = JsonConvert
                        .DeserializeObject<_DBSources>(settingFileContent)
                        .DatabaseSources.FirstOrDefault(x => x.DataSourceKeyName.ToLower() == dataSourceKeyName.ToLower());
                }
                else
                {
                    result.ErrorHandling.ErrorCode = 1;
                    result.ErrorHandling.ErrorMessage = $"{settingFilename} was not found.";
                }

                if (_dBSource is null || string.IsNullOrWhiteSpace(_dBSource.DataSourceKeyName))
                    return (new OutputDto { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "The DBSource is undefined" } }, null);
            }
            catch (Exception e)
            {
                result.ErrorHandling.ErrorCode = -1;
                result.ErrorHandling.ErrorMessage = e.Message;
                return (result, null);
            }

            if (_dBSource is null)
                return (new OutputDto { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "No Db Connection Info Was Found Accroding to the Current Environment." } }, null);

            var connectionParams = _dBSource.ConnectionParams.FirstOrDefault(x => x.Environment ==ArchSystem.Core.Services.Settings.BaseSettingService.GetBaseSetting().Environment);

            if (connectionParams is null)
                return (new OutputDto { ErrorHandling = new ErrorHandlingDto { ErrorCode = 1, ErrorMessage = "No Db Connection Info Was Found Accroding to the Current Environment." } }, null);
          
            var dBSource = new DBSource()
            {
                DataSourceKeyName = _dBSource.DataSourceKeyName,
                DBEngine = _dBSource.DBEngine,
                ProfilerIsActive = _dBSource.ProfilerIsActive,
                ConnectionParams = connectionParams
            };
            return (result, dBSource);
        }
        
        public static (OutputDto Output, string Content, bool IsErrorMarkNeeded) GetExecutedSpCommandAndResponse(SpInfoDto spInfoDto,
           IEnumerable<SpParamsDto> spParamsDto = null, object data = null)
        {
            var outputDto = new OutputDto
            {
                ErrorHandling = new ErrorHandlingDto()
            };
            bool isErrorMarkNeeded = false;
            var info = new StringBuilder($"Date & Time: {DateTime.Now}");
            info.Append(Environment.NewLine);
            try
            {
                info.Append($"Procedure Name: {spInfoDto.SchemaName}.{spInfoDto.ProcedureName}");
                info.Append(Environment.NewLine);
                if (!(spParamsDto is null))
                {
                    info.Append("-----------------------Params-----------------------");
                    info.Append(Environment.NewLine);
                    foreach (var item in spParamsDto)
                    {
                        info.Append($"{item.FieldName} --> {item.InputValue}");
                        info.Append(Environment.NewLine);
                        if (item.ParameterDirection == System.Data.ParameterDirection.Output ||
                            item.ParameterDirection == System.Data.ParameterDirection.InputOutput ||
                            item.ParameterDirection == System.Data.ParameterDirection.ReturnValue)
                        {
                            info.Append("-----------------------Output-------------------------");
                            info.Append(Environment.NewLine);
                            info.Append($"{item.FieldName} <-- {item.OutputValue}");
                            var jsonObj = ArchSystem.Core.Converter.Json.JsonStringToJsonObject(item.OutputValue?.ToString());
                            var errorCode = ArchSystem.Core.Services.GlobalServices.GetObjectProperty(jsonObj, "ErrorHandling.ErrorCode");
                            if (string.IsNullOrWhiteSpace(errorCode) == false)
                            {
                                isErrorMarkNeeded = errorCode == "-1";
                            }
                            info.Append(Environment.NewLine);
                        }
                    }
                }
                if (!(data is null))
                {
                    info.Append("-----------------------Data-------------------------");
                    info.Append(Environment.NewLine);
                    info.Append(ArchSystem.Core.Converter.Json.ObjectToJsonString(data));
                }
            }
            catch (Exception ex)
            {
                outputDto.ErrorHandling.ErrorCode = -1;
                outputDto.ErrorHandling.ErrorMessage = "An error has occured.";
                outputDto.ErrorHandling.ErrorTechnicalMessage = ex.FullMessage();
                info.Clear();
            }
            return (outputDto, info.ToString(), isErrorMarkNeeded);
        }               
    }
}
