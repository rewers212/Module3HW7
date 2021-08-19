using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3HW7
{
    public class Starter
    {
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
        private readonly LoggerService _loggerService;
        private readonly FileService _fileService;

        public Starter(
            LoggerService loggerService,
            FileService fileService)
        {
            _loggerService = loggerService;
            _fileService = fileService;
        }

        public void Run()
        {
            _loggerService.BackUpRef += BackUp;

            Task.Run(() =>
            {
                for (var i = 0; i < 50; i++)
                {
                    var k = i;
                    Task.Run(async () => { await WriteAsync($"Method 2 {k}"); });
                }
            });
            Task.Run(() =>
            {
                for (var i = 100; i < 150; i++)
                {
                    var k = i;
                    Task.Run(async () => { await WriteAsync($"Method 2 {k}"); });
                }
            });
        }

        private void BackUp()
        {
            _fileService.BackUp();
        }

        private async Task WriteAsync(string text)
        {
            await _semaphoreSlim.WaitAsync();

            await Task.Run(() => _loggerService.CreateLog(text, LogTypes.INFO));

            _semaphoreSlim.Release();
        }
    }
}