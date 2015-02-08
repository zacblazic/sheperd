using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Logging
{
    public class Log4NetLogger : ILogger
    {
        private ILog _log = LogManager.GetLogger(typeof(Log4NetLogger));
        public Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }

        public void Info(string message)
        {
            this._log.Info(message);
        }
    }
}
