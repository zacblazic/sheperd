using Sheperd.Core.Logging;
using Sheperd.Core.Sampling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class CounterProcessorProvider
    {
        private IEnumerable<PerformanceCounter> _processorTimeCounters;
        private ICounterManager _counterManager;
        private ILogger _logger;

        public CounterProcessorProvider(ICounterManager counterManager, ILogger logger)
        {
            this._counterManager = counterManager;
            this._logger = logger;
            this._processorTimeCounters = this._counterManager.GetInstances("Processor", "% Processor Time");
            this._processorTimeCounters.ToList().ForEach(ptc => {
                this._logger.Info("Initializing Processor Counter (" + ptc.InstanceName + "): " + ptc.NextValue().ToString());
            });
        }

        public ISampleSet TakeSample()
        {
            var samples = new List<ProcessorSample>();

            foreach (var ptc in this._processorTimeCounters)
            {
                var sample = new ProcessorSample()
                {
                    Time = DateTime.UtcNow,
                    Instance = ptc.InstanceName,
                    Usage = ptc.NextValue()
                };

                samples.Add(sample);

                this._logger.Info("Sample Processor Counter (" + sample.Instance + "):" + sample.Usage);
            }

            return new SampleSet(samples);
        }
    }
}
