using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Providers.System;
using Sheperd.Core.Providers;

namespace Sheperd.UnitTests.Providers
{
    [TestClass]
    public class SystemInfoProviderTest
    {
        private ISystemInfoProvider _systemInfoProvider;
        
        [TestInitialize]
        public void Init()
        {
            var context = new WmiContext();
            this._systemInfoProvider = new WmiSystemInfoProvider(context);
        }

        [TestMethod]
        public void ProcessorTest()
        {
            var processors = this._systemInfoProvider.Processors;
        }

        [TestMethod]
        public void MotherboardTest()
        {
            var motherboard = this._systemInfoProvider.Motherboard;
        }
    }
}
