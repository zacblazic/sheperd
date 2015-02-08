using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public class CounterManager : ICounterManager
    {
        public IEnumerable<PerformanceCounter> GetInstances(string categoryName, string counterName)
        {
            var category = PerformanceCounterCategory.GetCategories()
                .Where(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();

            var counters = category.GetInstanceNames()
                .Select(i => new PerformanceCounter(categoryName, counterName, i))
                .ToList();

            return counters;
        }
    }
}
