using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Monitoring;
using System.Management;


namespace Sheperd.UnitTests.Monitoring
{
    [TestClass]
    public class WmiTest
    {
        [TestMethod]
        public void GetProcessorUtilization()
        {
            var processorResults = WmiHelper.Query<ProcessorUtilization>(Environment.MachineName,
                "SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor",
                results => results.Select(mo => new ProcessorUtilization()
                    {
                        Name = mo["Name"].ToString() == "_Total" ? "Total" : mo["Name"].ToString(),
                        Utilization = (UInt64)mo["PercentProcessorTime"]
                    }
                ));
        }

        [TestMethod]
        public void GetWindowsServices()
        {
            var managementObjectResults = WmiHelper.Query<ManagementObject>(Environment.MachineName,
                "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory",
                results => results.Select(mo => mo));
        }

        [TestMethod]
        public void GetMemoryUtilization()
        {
            var memoryResults = WmiHelper.Query<MemoryUtilization>(Environment.MachineName,
                "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory",
                results => results.Select(mo => new MemoryUtilization()
                    {
                        AvailableBytes = (UInt64)mo["AvailableBytes"]
                    }));
        }

        [TestMethod]
        public void GetMemoryCapacity()
        {
            var memoryResults = WmiHelper.Query<MemoryUtilization>(Environment.MachineName,
                "SELECT * FROM Win32_PhysicalMemory ",
                results => results.Select(mo => new MemoryUtilization()
                {
                    Capacity = (UInt64)mo["Capacity"]
                }));
        }

        public class ProcessorUtilization
        {
            public string Name { get; set; }
            public UInt64 Utilization { get; set; }
        }

        public class MemoryUtilization
        {
            public UInt64 Capacity { get; set; }
            public UInt64 AvailableBytes { get; set; }
        }
    }
}
