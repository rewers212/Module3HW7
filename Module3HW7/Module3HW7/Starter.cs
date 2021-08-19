using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW7
{
    public class Starter
    {
        private readonly LoggerService _logger;

        public Starter(LoggerService logger)
        {
            _logger = logger;
        }

        internal void Run()
        {
            _logger.FirstMethod();
            _logger.SecondMethod();
        }
    }
}
