using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class CounterGroup
    {
        private List<PerformanceCounter> _counters = new List<PerformanceCounter>();

        public CounterGroup(string counterName, IEnumerable<PerformanceCounter> counters)
        {
            this.CounterName = counterName;
            this._counters.AddRange(counters);
        }

        public string CounterName { get; private set; }

        public IEnumerable<PerformanceCounter> Counters
        {
            get
            {
                return this._counters;
            }
        }
    }
}
