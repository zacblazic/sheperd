using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Providers;
using System.Collections.Generic;
using Sheperd.Core.Sampling;
using System.Threading;
using System.Management;

namespace Sheperd.UnitTests.Providers
{
    [TestClass]
    public class CounterProcessorProviderTest
    {
        private CounterProcessorProvider _provider;

        [TestInitialize]
        public void Init()
        {
            var counterManager = new CounterManager();
            this._provider = new CounterProcessorProvider(counterManager);
        }

        [TestMethod]
        public void Take20CounterSamples()
        {
            var sampleSets = new List<ISampleSet>();

            int sampleCount = 100;
            for (int i = 0; i < sampleCount; i++)
            {
                sampleSets.Add(this._provider.TakeSample());
            }
        }
    }
}
