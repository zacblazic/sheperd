using Sheperd.Core.Sampling.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheperd.Core.Providers;
using Sheperd.Core.Sampling;
using System.Management;

namespace Sheperd.Core.Providers
{
    public class WmiProcessorProvider
    {
        private const string ProcessorQuery = "SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor";
        private IWmiContext _context;

        public WmiProcessorProvider(IWmiContext context)
        {
            this._context = context;
        }

        public ISampleSet TakeSample()
        {
            var mos = this._context.Query<ManagementObject>(ProcessorQuery, mo => mo.ToList()).ToList();

            var samples = this._context.Query<UsageSample>(ProcessorQuery, mo => new UsageSample()
            {
                Time = DateTime.UtcNow,
                PercentProcessorTime = mo.GetPropertyValueOrDefault<float>("PercentProcessorTime", 0)
            });

            return new SampleSet(samples);
        }
    }
}
