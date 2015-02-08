using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace Sheperd.UnitTests.Providers
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void GetCounterData()
        {
            var category = PerformanceCounterCategory.GetCategories()
                                .Where(c => c.CategoryName == "Processor")
                                .SingleOrDefault();

            //var counters = category.GetInstanceNames()
            //                       .Select(i => new PerformanceCounter(category.CategoryName, "% Processor Time", i))
            //                       .ToList();

            var counters = category.GetInstanceNames()
                                   .SelectMany(i => category.GetCounters(i))
                                   .ToList();


        }
    }
}
