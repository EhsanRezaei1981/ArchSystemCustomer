using ArchSystem.Dto.Models;

namespace DBDriver.Interfaces
{
    public interface IProcedureInvoker
    {
        Task<(DBDriverService.OutputDto Output, IEnumerable<TOutputModel> OutputModel, IEnumerable<SpParamsDto> SpParams)> InvokeSp<TOutputModel>(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null) where TOutputModel : class;

        Task<(DBDriverService.OutputDto Output, IEnumerable<SpParamsDto> SpParams)> InvokeSp(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null);

        Task<DBDriverService.OutputDto<IEnumerable<TOutputModel>>> InvokeSpReturnsDataSet<TOutputModel>(
            SpInfoDto spInfoDto, IEnumerable<SpParamsDto> spParamsDto = null) where TOutputModel : class;
    }
}
