using ArchSystem.Dto.Models;

namespace ArchSystem.DBDriver.Services
{
    public interface IDBService : IDBDriverService
    {
    }

    public class DBService : IDBService
    {
        private readonly IDBDriverService _dBDriverService;
        public DBService(IDBDriverService dBDriverService)
        {
            _dBDriverService = dBDriverService;
        }

        public async Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto Output, IEnumerable<TOutputModel> OutputModel, IEnumerable<SpParamsDto> SpParams)> InvokeSp<TOutputModel>
            (SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class
        {
            return await _dBDriverService.InvokeSp<TOutputModel>(spInfoDto, spParamsDto, dbConnection);
        }

        public async Task<(ArchSystem.Dto.Models.DBDriverService.OutputDto Output, IEnumerable<SpParamsDto> SpParams)> InvokeSp
            (SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null)
        {
            return await _dBDriverService.InvokeSp(spInfoDto, spParamsDto, dbConnection);
        }

        public async Task<Dto.Models.DBDriverService.OutputDto<IEnumerable<TOutputModel>>> InvokeSpReturnsDataSet<TOutputModel>
            (SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null, DBConnection dbConnection = null) where TOutputModel : class
        {
            return await _dBDriverService.InvokeSpReturnsDataSet<TOutputModel>(spInfoDto, spParamsDto, dbConnection);
        }
    }
}
