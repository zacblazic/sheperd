using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Providers;
using System.Collections.Generic;
using Sheperd.Core.Sampling;
using System.Threading;
using System.Management;
using Sheperd.Core.Logging;

namespace Sheperd.UnitTests.Providers
{
    [TestClass]
    public class CounterProcessorProviderTest
    {
        private CounterProcessorProvider _provider;

        [TestInitialize]
        public void Init()
        {
            var logger = new Log4NetLogger();
            var counterManager = new CounterManager();
            this._provider = new CounterProcessorProvider(counterManager, logger);
        }

        [TestMethod]
        public void Take20CounterSamples()
        {
            var sampleSets = new List<ISampleSet>();

            int sampleCount = 1000;
            for (int i = 0; i < sampleCount; i++)
            {
                sampleSets.Add(this._provider.TakeSample());
            }
        }

        [TestMethod]
        public void Take1000CounterSamples()
        {
            var sampleSets = new List<ISampleSet>();

            int sampleCount = 1000;
            for (int i = 0; i < sampleCount; i++)
            {
                Thread.Sleep(1000);
                sampleSets.Add(this._provider.TakeSample());
            }

            var sum = sampleSets.SelectMany(s => s.OfType<ProcessorSample>().Where(sm => sm.Instance == "_Total").ToList()).Sum(s => s.Usage);
            var average = sum / sampleCount;
        }
    }
}
