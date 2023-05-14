using System.Data;

namespace ArchSystem.Dto.Models
{
    public interface IGenericData<TModel>
    {
        TModel Data { get; set; }
    }
    public interface IGenericDataList<TModel> where TModel : class
    {
        long? TotalRecords { get; set; }
        IEnumerable<TModel> Data { get; set; }
    }

    public interface IOutputDto
    {
        Dto.Models.ErrorHandlingDto ErrorHandling { get; set; }
    }

    public class OutputDto: IOutputDto
    {
        public Dto.Models.ErrorHandlingDto ErrorHandling { get; set; }
        public OutputDto()
        {
            ErrorHandling = new ErrorHandlingDto();
        }
    }

    public class OutputDto<TModel> : OutputDto, IGenericData<TModel>
    {
        public TModel Data { get; set; }
    }

    public class OutputListDto<TModel> : OutputDto, IGenericDataList<TModel> where TModel : class
    {
        public long? TotalRecords { get; set; }
        public IEnumerable<TModel> Data { get; set; }
    }
}
