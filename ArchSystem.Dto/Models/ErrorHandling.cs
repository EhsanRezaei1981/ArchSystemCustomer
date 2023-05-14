using ArchSystem.Dto.Enums;
using Newtonsoft.Json.Converters;

namespace ArchSystem.Dto.Models
{
    public interface IErrorHandling
    {
        int ErrorCode { get; set; }
        string ErrorMessage { get; set; }
        string ErrorTechnicalMessage { get; set; }
        string ErrorKey { get; set; }
        bool? ErrorMustBeSeenByUser { get; set; }
        Int32? ErrorLogId { get; set; }
        bool IsSuccessful { get; }
        ErrorLevel? ErrorLevel { get; set; }
    }
    public class ErrorHandlingDto : IErrorHandling
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorTechnicalMessage { get; set; }
        public string ErrorKey { get; set; }
        public bool? ErrorMustBeSeenByUser { get; set; } = true;
        public int? ErrorLogId { get; set; }
        public bool IsSuccessful => ErrorCode == 0;
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public ErrorLevel? ErrorLevel { get; set; }
    }
}
