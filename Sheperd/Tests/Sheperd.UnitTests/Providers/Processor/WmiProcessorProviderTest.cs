using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Providers;
using System.Collections.Generic;
using Sheperd.Core.Sampling;

namespace Sheperd.UnitTests.Providers.Processor
{
    [TestClass]
    public class WmiProcessorProviderTest
    {
        private WmiProcessorProvider _provider;

        [TestInitialize]
        public void Init()
        {
            var context = new WmiContext();
            this._provider = new WmiProcessorProvider(context);
        }

        [TestMethod]
        public void Take20WmiSamples()
        {
            var sampleSets = new List<ISampleSet>();

            int sampleCount = 20;
            for (int i = 0; i < sampleCount; i++)
            {
                sampleSets.Add(this._provider.TakeSample());
            }
        }
    }
}
