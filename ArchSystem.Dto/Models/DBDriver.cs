namespace ArchSystem.Dto.Models
{
    public abstract class DBDriverService
    {
        public class OutputDto : Dto.Models.OutputDto
        {
            public Dto.Models.DBEngineLastConnection DBEngineLastConnection { get; set; }

        }
        public class OutputDto<TModel> : Dto.Models.OutputDto<TModel>
        {
            public Dto.Models.DBEngineLastConnection DBEngineLastConnection { get; set; }
        }
    }
}
