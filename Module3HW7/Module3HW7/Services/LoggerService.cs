using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3HW7
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly LoggerConfig _loggerConfig;
        private int _countLines = 0;

        public LoggerService(
            IConfigService configService,
            IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _loggerConfig = _configService.Config.LoggerConfig;
            FileServiceInit();
        }

        public event Action BackUpRef;

        public void CreateLog(string text, LogTypes logTypes)
        {
            var log = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)} {logTypes}: {text}";
            _fileService.WriteToFile(log);
            _fileService.WriteToFileAsync(log);
            _countLines++;
            BackUp(_countLines);
        }

        private void BackUp(int count)
        {
            if (count % _loggerConfig.NumbersOfLinesToBackUp == 0)
            {
                BackUpRef.Invoke();
            }
        }

        private void FileServiceInit()
        {
            var directionName = _configService.Config.LoggerConfig.DirectoryPath;
            var fileName = DateTime.UtcNow.ToString(_configService.Config.LoggerConfig.TimeFormat);
            var fileExtencion = _configService.Config.LoggerConfig.FileExtension;
            _fileService.Init(directionName, fileName, fileExtencion);
        }
    }
}