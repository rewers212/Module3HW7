using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7
{
    public interface IFileService
    {
        public void Init(string directionName, string fileName, string fileExtension);
        public void WriteToFile(string text);
        public void BackUp();
        public Task WriteToFileAsync(string text);
    }
}