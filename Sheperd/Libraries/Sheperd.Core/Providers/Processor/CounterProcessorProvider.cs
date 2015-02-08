using Sheperd.Core.Sampling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class CounterProcessorProvider
    {
        private IList<PerformanceCounter> _counters = new List<PerformanceCounter>();
        private ICounterManager _counterManager;

        public CounterProcessorProvider(ICounterManager counterManager)
        {
            this._counterManager = counterManager;
        }

        public ISampleSet TakeSample()
        {
            var processorTimeCounters = this._counterManager.GetInstances("Processor", "% Processor Time");

            var samples = (from pt in processorTimeCounters
                           select new ProcessorSample()
                           {
                               Time = DateTime.UtcNow,
                               Instance = pt.InstanceName,
                               Usage = pt.NextValue()
                           })
                           .ToList();

            return new SampleSet(samples);
        }
    }
}
