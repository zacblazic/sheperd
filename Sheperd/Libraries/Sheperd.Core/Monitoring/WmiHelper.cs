using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Monitoring
{
    public static class WmiHelper
    {
        public static IList<T> Query<T>(string machineName, string query, Func<IEnumerable<ManagementObject>, IEnumerable<T>> conversion)
        {
            var scope = CreateManagementScope(machineName);
            using (var searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query)))
            using (var results = searcher.Get())
            {
                 var r = results.Cast<ManagementObject>();
                 return conversion(r).ToList();
            }
        }

        private static ManagementScope CreateManagementScope(string machineName)
        {
            var scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", machineName), CreateConnectionOptions(machineName));
            return scope;
        }

        private static ConnectionOptions CreateConnectionOptions(string machineName)
        {
            var options = new ConnectionOptions();
            if (machineName == Environment.MachineName)
            {
                return options;
            }

            switch (machineName)
            {
                case "localhost":
                case "127.0.0.1":
                    return options;
            }

            return null;
        }
    }
}
