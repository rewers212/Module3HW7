using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7
{
    public interface ILoggerService
    {
        public event Action BackUpRef;
        public void CreateLog(string message, LogTypes logTypes);
    }
}