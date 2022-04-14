using System.Collections.Generic;

namespace EduHome.Services.Interfaces
{
    public interface ISettingService
    {
        Dictionary<string, string> GetSettings();
    }
}
