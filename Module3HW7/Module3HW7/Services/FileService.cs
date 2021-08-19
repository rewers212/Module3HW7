using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW7.Services.Abstract;

namespace Module3HW7.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private StreamWriter _streamWriter;
        private DirectoryInfo _directoryInfo;
        private string _filePath;
        private int _count = 1;

        public FileService(IConfigService configService)
        {
            _configService = configService;
            _filePath = GetFilePath(_configService.Config.LoggerConfig.DirectoryPath);
            CreateDirectory(_configService.Config.LoggerConfig.DirectoryPath);
        }

        public void WriteToFile(string text)
        {
            _streamWriter = new StreamWriter(_filePath, true);
            _streamWriter.WriteLine(text);
            _streamWriter.Close();
        }

        public void BackUp()
        {
            var directoryName = _configService.Config.LoggerConfig.DirectoryPath;
            CreateDirectory(directoryName);
            File.Copy(_filePath, GetFilePath(directoryName, _count.ToString()));
            _count++;
        }

        private string GetFilePath(string directoryName, string count = "")
        {
            if (count != string.Empty)
            {
                count = $"({count})";
            }

            var fileName = DateTime.UtcNow.ToString(_configService.Config.LoggerConfig.NameFormat);
            var fileExtension = _configService.Config.LoggerConfig.FileExtension;

            return $"{directoryName}{fileName}{count}{fileExtension}";
        }

        private void CreateDirectory(string directoryPath)
        {
            _directoryInfo = new DirectoryInfo(directoryPath);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
        }
    }
}
