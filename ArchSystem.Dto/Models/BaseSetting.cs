using Newtonsoft.Json.Converters;

namespace ArchSystem.Dto.Models
{
    public interface IBaseSettingDto
    {
        Dto.Enums.Environment? Environment { get; set; }
        bool UseMemberCasing { get; set; } 
    }
    public class BaseSettingDto: IBaseSettingDto
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public Dto.Enums.Environment? Environment { get; set; }
        public bool UseMemberCasing { get; set; } = true;
    }
}
