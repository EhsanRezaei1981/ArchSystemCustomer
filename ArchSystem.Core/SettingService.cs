using ArchSystem.Dto.Models;
using Newtonsoft.Json;

namespace ArchSystem.Core.Services.Settings
{
    public static class BaseSettingService
    {
        private static BaseSettingDto? _baseSettingDto;
        
        public static BaseSettingDto GetBaseSetting() {
            if (_baseSettingDto is not null)
                return _baseSettingDto;

            var appStartPath = AppDomain.CurrentDomain.BaseDirectory;
            const string settingDirectoryName = "Settings";
            const string settingFilename = "Base.Settings.json";
            string fileFullPath = $"{appStartPath}/{settingDirectoryName}/{settingFilename }";

            var baseSettingDto = new BaseSettingDto();
            if (File.Exists(fileFullPath))
            {
                var settingFilenameContent = File.ReadAllText(fileFullPath);
                baseSettingDto = JsonConvert.DeserializeObject<BaseSettingDto>(settingFilenameContent);
            }

            baseSettingDto ??= new BaseSettingDto();

            baseSettingDto.Environment ??= ArchSystem.Dto.Enums.Environment.DEV;
           
           _baseSettingDto = baseSettingDto;
            
            return baseSettingDto;
        }
    }
}