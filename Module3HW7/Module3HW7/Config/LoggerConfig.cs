using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7
{
    public class LoggerConfig
    {
        public string TimeFormat { get; set; }
        public string NameFormat { get; set; }
        public string DirectoryPath { get; set; }
        public string FileExtension { get; set; }
        public int NumbersOfLinesToBackUp { get; set; }
        public string BackUpDirectoryName { get; set; }
    }
}