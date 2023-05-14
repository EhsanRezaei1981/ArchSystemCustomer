using ArchSystem.Dto.Enums;

namespace ArchSystem.Core.Extensions
{
    public static class ErrorHandling
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }
        public static string FullMessage(this Exception ex) => $"{ex.Message} {(ex.InnerException != null ? ($" -> Inner Exception:{ex.InnerException.Message}") : "")}";
        
        public static ArchSystem.Dto.Models.OutputDto GetErrorHandling(this Exception ex,
            string errorMessage = null, bool errorMustBeSeenByUser = true, string errorKey = null,
            ErrorLevel? errorLevel = null) => new Dto.Models.OutputDto
            {
                ErrorHandling = new Dto.Models.ErrorHandlingDto
                {
                    ErrorCode = -1,
                    ErrorMessage = string.IsNullOrWhiteSpace(errorMessage) ? "An error has occurred. Please see the ErrorTechnicalMessage." : errorMessage,
                    ErrorTechnicalMessage = ex.FullMessage(),
                    ErrorMustBeSeenByUser = errorMustBeSeenByUser,
                    ErrorKey = errorKey,
                    ErrorLevel = errorLevel
                }
            };
    }
}
