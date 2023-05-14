using ArchSystem.Dto.Enums;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ArchSystem.Dto.Models
{
    public interface IPagination 
    {
        [Range(0, int.MaxValue)]
        int? PageIndex { get; set; }

        [Range(0, int.MaxValue)]
        public int? PageSize { get; set; }

        string OrderBy { get; set; }
        OrderMethod? OrderMethod { get; set; }
        public bool PaginationMustBeIgnored { get; set; }
    }

    public class Pagination: IPagination
    {
        [Range(0, int.MaxValue)]
        public int? PageIndex { get; set; }

        [Range(0, int.MaxValue)]
        public int? PageSize { get; set; }

        public string OrderBy { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public OrderMethod? OrderMethod { get; set; }
        public bool PaginationMustBeIgnored { get; set; }
    }
}
