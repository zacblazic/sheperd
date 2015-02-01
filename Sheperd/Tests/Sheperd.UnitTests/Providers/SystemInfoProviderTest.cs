using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Providers.System;
using Sheperd.Core.Providers;
using Moq;
using Sheperd.Core.Providers.System.Hardware;
using System.Collections.Generic;
using System.Management;
using System.Linq;

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
        public void GetProcessorsTest()
        {
            var processors = this._systemInfoProvider.Processors;
            var processor = processors.FirstOrDefault();

            Assert.IsNotNull(processor);
            Assert.IsFalse(string.IsNullOrEmpty(processor.Name));
            Assert.IsFalse(string.IsNullOrEmpty(processor.Manufacturer));
            Assert.IsTrue(processor.Architecture >= 0 && processor.Architecture != (int)ArchitectureType.None);
        }

        [TestMethod]
        public void GetMotherboardTest()
        {
            var motherboard = this._systemInfoProvider.Motherboard;

            Assert.IsNotNull(motherboard);
        }

        [TestMethod]
        public void GetMemoryModulesTest()
        {
            var memoryModules = this._systemInfoProvider.MemoryModules;
            var memoryModule = memoryModules.FirstOrDefault();

            Assert.IsNotNull(memoryModule);
            Assert.IsTrue(memoryModule.SpeedMHz > 0);
            Assert.IsTrue(memoryModule.CapacityBytes > 0);
        }

        [TestMethod]
        public void GetDisksTest()
        {
            var disks = this._systemInfoProvider.Disks;
        }

        [TestMethod]
        public void GetNetworkAdaptersTest()
        {
            var adapters = this._systemInfoProvider.NetworkAdapters;
            var adapter = adapters.FirstOrDefault();

            Assert.IsNotNull(adapter);
            Assert.IsFalse(string.IsNullOrEmpty(adapter.Name));
            Assert.IsFalse(string.IsNullOrEmpty(adapter.MacAddress));
        }
    }
}
