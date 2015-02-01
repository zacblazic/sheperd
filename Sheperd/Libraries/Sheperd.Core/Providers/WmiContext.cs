using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class WmiContext : IWmiContext
    {
        private string _machineName;
        private ManagementScope _managementScope;

        public WmiContext() : this(Environment.MachineName)
        {
        }

        public WmiContext(string machineName)
        {
            this._machineName = machineName;
            this._managementScope = CreateManagementScope(machineName);
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

        public IEnumerable<T> Query<T>(string query, Func<ManagementObject, T> conversion)
        {
            return this.Query<T>(query, mobs => mobs.Select(mo => conversion(mo)));
        }

        public IEnumerable<T> Query<T>(string query, Func<IEnumerable<ManagementObject>, IEnumerable<T>> conversion)
        {
            using (var searcher = new ManagementObjectSearcher(this._managementScope, new ObjectQuery(query)))
            using (var results = searcher.Get())
            {
                var r = results.Cast<ManagementObject>();
                return conversion(r).ToList();
            }
        }
    }
}
