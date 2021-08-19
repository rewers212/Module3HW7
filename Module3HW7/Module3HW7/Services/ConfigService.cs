using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module3HW7
{
    public class ConfigService : IConfigService
    {
        private const string Path = "Configs/Config.json";
        private Config _config;
        public ConfigService()
        {
            ConfigInit();
        }

        public Config Config => _config;
        private void ConfigInit()
        {
            var text = File.ReadAllText(Path);
            _config = JsonConvert.DeserializeObject<Config>(text);
        }
    }
}
