using ArchSystem.DBDriver.Services;
using ArchSystem.Dto.Models;
using ArchSystem.Core.Extensions;
using System.Xml.Linq;

namespace ArchSystem.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IDBService _dbService;
        public CustomerService(IDBService dbService)
        {
            _dbService = dbService;
        }
        public async Task<Dto.Models.Customer.Create.OutputDto> Create(Dto.Models.Customer.Create.InputDto iModel)
        {
            try
            {
                var spParams = new List<SpParamsDto> {
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Name",
                            InputValue=iModel.Name
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Surname",
                            InputValue=iModel.Surname
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="IDNumber",
                            InputValue=iModel.IDNumber
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Email",
                            InputValue=iModel.Email
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.Int64,
                            FieldName="Tel",
                            InputValue=iModel.Tel
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Country",
                            InputValue=iModel.Country
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName=Public.OutputJsonParamName,
                            ParameterDirection=System.Data.ParameterDirection.InputOutput
                    }
            };

                var (baseResultDto, spParamsDto) = await _dbService.InvokeSp(
                 spInfoDto: new SpInfoDto
                 {
                     DataSourceKeyName =Public.DataSourceKeyName,
                     ProcedureName = "_Sp_Customer_CreateUpdate",
                     SchemaName = Public.SchemaName
                 },
                 spParamsDto: spParams
                 );

                if (!baseResultDto.ErrorHandling.IsSuccessful)
                {
                    return new ArchSystem.Dto.Models.Customer.Create.OutputDto
                    {
                        ErrorHandling = baseResultDto.ErrorHandling
                    };
                }
                var resultJson = spParamsDto.FirstOrDefault(x => string.Compare(x.FieldName, Public.OutputJsonParamName, true) == 0);
                var result = ArchSystem.Core.Converter.Json.JsonToModel<ArchSystem.Dto.Models.Customer.Create.OutputDto>(resultJson.OutputValue.ToString());
                return result;
            }
            catch (Exception ex)
            {
                var result = new ArchSystem.Dto.Models.Customer.Create.OutputDto
                {
                    ErrorHandling = ex.GetErrorHandling().ErrorHandling
                };
                return result;
            }
        }

        public async Task<Dto.Models.Customer.Delete.OutputDto> Delete(Dto.Models.Customer.Delete.InputDto iModel)
        {
            try
            {
                var spParams = new List<SpParamsDto> {
                    new SpParamsDto{
                            DataType=System.Data.DbType.Int64,
                            FieldName="CustomerId",
                            InputValue=iModel.CustomerId
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="LastUpdateDateTime",
                            InputValue=iModel.LastUpdateDateTime
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName=Public.OutputJsonParamName,
                            ParameterDirection=System.Data.ParameterDirection.InputOutput
                    }
            };

                var (baseResultDto, spParamsDto) = await _dbService.InvokeSp(
                 spInfoDto: new SpInfoDto
                 {
                     DataSourceKeyName = Public.DataSourceKeyName,
                     ProcedureName = "_Sp_Customer_Delete",
                     SchemaName = Public.SchemaName
                 },
                 spParamsDto: spParams
                 );

                if (!baseResultDto.ErrorHandling.IsSuccessful)
                {
                    return new Dto.Models.Customer.Delete.OutputDto
                    {
                        ErrorHandling = baseResultDto.ErrorHandling
                    };
                }
                var resultJson = spParamsDto.FirstOrDefault(x => string.Compare(x.FieldName, Public.OutputJsonParamName, true) == 0);
                var result = ArchSystem.Core.Converter.Json.JsonToModel<Dto.Models.Customer.Delete.OutputDto>(resultJson.OutputValue.ToString());
                return result;
            }
            catch (Exception ex)
            {
                var result = new Dto.Models.Customer.Delete.OutputDto
                {
                    ErrorHandling = ex.GetErrorHandling().ErrorHandling
                };
                return result;
            }
        }

        public async Task<Dto.Models.Customer.Retrieve.OutputDto> Retrieve(ArchSystem.Dto.Models.Customer.Retrieve.InputDto iModel)
        {
            try
            {
                var spParams = new List<SpParamsDto> {
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Filter",
                            InputValue=ArchSystem.Core.Converter.Json.ObjectToJsonString( iModel.Filter)

                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName=Public.OutputJsonParamName,
                            ParameterDirection=System.Data.ParameterDirection.InputOutput
                    }
            };

                var result = await _dbService.InvokeSpReturnsDataSet<Dto.Models.Customer.Retrieve.BaseOutputDto>(
                 spInfoDto: new SpInfoDto
                 {
                     DataSourceKeyName = Public.DataSourceKeyName,
                     ProcedureName = "_Sp_Customer_Retrieve",
                     SchemaName = Public.SchemaName
                 },
                 spParamsDto: spParams
                 );

                if (!result.ErrorHandling.IsSuccessful)
                {
                    return new Dto.Models.Customer.Retrieve.OutputDto
                    {
                        ErrorHandling = result.ErrorHandling
                    };
                }
                return new Dto.Models.Customer.Retrieve.OutputDto
                {
                    ErrorHandling = result.ErrorHandling,
                    Data = result.Data,
                };
            }
            catch (Exception ex)
            {
                var result = new Dto.Models.Customer.Retrieve.OutputDto
                {
                    ErrorHandling = ex.GetErrorHandling().ErrorHandling
                };
                return result;
            }
        }

        public async Task<Dto.Models.Customer.Update.OutputDto> Update(Dto.Models.Customer.Update.InputDto iModel)
        {
            try
            {
                var spParams = new List<SpParamsDto> {
                    new SpParamsDto{
                            DataType=System.Data.DbType.Int64,
                            FieldName="CustomerId",
                            InputValue=iModel.CustomerId
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="LastUpdateDateTime",
                            InputValue=iModel.LastUpdateDateTime
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Name",
                            InputValue=iModel.Name
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Surname",
                            InputValue=iModel.Surname
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="IDNumber",
                            InputValue=iModel.IDNumber
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Email",
                            InputValue=iModel.Email
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.Int64,
                            FieldName="Tel",
                            InputValue=iModel.Tel
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName="Country",
                            InputValue=iModel.Country
                    },
                    new SpParamsDto{
                            DataType=System.Data.DbType.String,
                            FieldName=Public.OutputJsonParamName,
                            ParameterDirection=System.Data.ParameterDirection.InputOutput
                    }
            };

                var (baseResultDto, spParamsDto) = await _dbService.InvokeSp(
                 spInfoDto: new SpInfoDto
                 {
                     DataSourceKeyName = Public.DataSourceKeyName,
                     ProcedureName = "_Sp_Customer_CreateUpdate",
                     SchemaName = Public.SchemaName
                 },
                 spParamsDto: spParams
                 );

                if (!baseResultDto.ErrorHandling.IsSuccessful)
                {
                    return new ArchSystem.Dto.Models.Customer.Update.OutputDto
                    {
                        ErrorHandling = baseResultDto.ErrorHandling
                    };
                }
                var resultJson = spParamsDto.FirstOrDefault(x => string.Compare(x.FieldName, Public.OutputJsonParamName, true) == 0);
                var result = ArchSystem.Core.Converter.Json.JsonToModel<ArchSystem.Dto.Models.Customer.Update.OutputDto>(resultJson.OutputValue.ToString());
                return result;
            }
            catch (Exception ex)
            {
                var result = new ArchSystem.Dto.Models.Customer.Update.OutputDto
                {
                    ErrorHandling = ex.GetErrorHandling().ErrorHandling
                };
                return result;
            }
        }

        public async Task<Dto.Models.Customer.Retrieve.ExportToXml.OutputDto> ExportToXml()
        {
            try
            {
                var result = await Retrieve(new Dto.Models.Customer.Retrieve.InputDto
                {
                    Filter = new Dto.Models.Customer.Retrieve.Filter
                    {
                        Pagination = new Pagination
                        {
                            PaginationMustBeIgnored = true
                        }
                    }
                });

                if (!result.ErrorHandling.IsSuccessful)
                {
                    return new ArchSystem.Dto.Models.Customer.Retrieve.ExportToXml.OutputDto
                    {
                        ErrorHandling = result.ErrorHandling
                    };
                }
                if (result.Data is null || result.Data.Count() == 0)
                    return new Dto.Models.Customer.Retrieve.ExportToXml.OutputDto
                    {
                        ErrorHandling = new ErrorHandlingDto
                        {
                            ErrorCode = 1,
                            ErrorMessage = "No data found"
                        }
                    };

                var appStartPath = AppDomain.CurrentDomain.BaseDirectory;
                const string exportFolderName = "Report";
                string directory = System.IO.Path.Combine(appStartPath, exportFolderName);
                string id = Guid.NewGuid().ToString();
                string exportFilename = $"Report-{id}.xml";
                string fileFullPath = System.IO.Path.Combine(directory, exportFilename);
                
                if (!System.IO.Directory.Exists(directory))
                    System.IO.Directory.CreateDirectory(directory);

                var xmlElements = new XElement("Customers", result.Data.ToList().Select(x => new XElement("Customer",

                    new XElement("CustomerId", x.CustomerId),
                    new XElement("Name", x.Name),
                    new XElement("Surname", x.Surname),
                    new XElement("IDNumber", x.IDNumber),
                    new XElement("Email", x.Email),
                    new XElement("Tel", x.Tel),
                    new XElement("Country", x.Country),
                    new XElement("CreationDateTime", x.CreationDateTime),
                    new XElement("LastUpdateDateTime", x.LastUpdateDateTime)
                    )));

                xmlElements.Save(fileFullPath);
                return new Dto.Models.Customer.Retrieve.ExportToXml.OutputDto
                {
                    ErrorHandling = new ErrorHandlingDto
                    {
                        ErrorMessage = $"Export to xml is done successfully. File is available through {fileFullPath}"
                    },
                    Data = new Dto.Models.Customer.Retrieve.ExportToXml.BaseOutputDto
                    {
                        Filename = fileFullPath
                    }
                };
            }
            catch (Exception ex) {
                var result = new Dto.Models.Customer.Retrieve.ExportToXml.OutputDto
                {
                    ErrorHandling = ex.GetErrorHandling().ErrorHandling
                };
                return result;
            }
        }
    }    

}
