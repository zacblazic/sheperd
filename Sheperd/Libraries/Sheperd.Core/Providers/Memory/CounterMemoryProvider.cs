using Sheperd.Core.Logging;
using Sheperd.Core.Sampling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class CounterMemoryProvider
    {
        private List<CounterGroup> _counterGroups;
        private ICounterManager _counterManager;
        private ILogger _logger;

        public CounterMemoryProvider(ICounterManager counterManager, ILogger logger)
        {
            this._counterManager = counterManager;
            this._logger = logger;
        }

        public void InitCounters()
        {
            this._counterGroups.Add(new CounterGroup("Available Bytes", this._counterManager.GetInstances("Memory", "Available Bytes")));
            this._counterGroups.Add(new CounterGroup("Commit Limit", this._counterManager.GetInstances("Memory", "Commit Limit")));
        }

        public ISampleSet TakeSample()
        {
            throw new NotImplementedException();
        }
    }
}
