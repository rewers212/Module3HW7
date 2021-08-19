using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3HW7
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
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

        public void Init(string directionName, string fileName, string fileExtension)
        {
            var path = GetFilePath(_configService.Config.LoggerConfig.DirectoryPath);
            _filePath = path;
            CreateDirectory(directionName);
            _streamWriter = new StreamWriter(path, true);
        }

        public void WriteToFile(string text)
        {
            _streamWriter.WriteLine(text);
        }

        public void BackUp()
        {
            var directoryName = _configService.Config.LoggerConfig.BackUpDirectoryName;
            CreateDirectory(directoryName);
            File.Copy(_filePath, GetFilePath(directoryName, _count.ToString()));
            _count++;
        }

        public async Task WriteToFileAsync(string text)
        {
            await _semaphoreSlim.WaitAsync();
            await _streamWriter.WriteLineAsync(text);
            await _streamWriter.FlushAsync();
            _semaphoreSlim.Release();
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
