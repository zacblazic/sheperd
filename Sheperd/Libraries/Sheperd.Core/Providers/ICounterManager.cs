using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public interface ICounterManager
    {
        IEnumerable<PerformanceCounter> GetInstances(string categoryName, string counterName);
    }
}
