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
        public StreamWriter _StreamWriter;
        private DirectoryInfo _directoryInfo;


        public void WriteToFile(string text)
        {
            _StreamWriter = new StreamWriter()
        }
    }
}
