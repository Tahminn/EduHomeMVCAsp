using EduHome.Data;
using EduHome.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EduHome.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }
        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            return settings;
        }
    }
}
