using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public interface IWmiContext
    {
        IEnumerable<T> Query<T>(string query, Func<ManagementObject, T> conversion);
        IEnumerable<T> Query<T>(string query, Func<IEnumerable<ManagementObject>, IEnumerable<T>> conversion);
    }
}
