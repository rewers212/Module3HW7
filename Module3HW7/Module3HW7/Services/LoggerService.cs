using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Module3HW7.Services.Abstract;

namespace Module3HW7
{
    public class LoggerService
    {
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly LoggerConfig _loggerConfig;

        public LoggerService(
            IConfigService configService,
            IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _loggerConfig = _configService.Config.LoggerConfig;
        }

        public event Action BackUpRef;

        public void CreateLog(string text, )
    }
}
