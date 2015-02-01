using Sheperd.Core.Providers.System.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers.System
{
    public class WmiSystemInfoProvider : ISystemInfoProvider
    {
        private const string ProcessorQuery = "SELECT Architecture,DeviceID,L2CacheSize,L3CacheSize,Manufacturer,MaxClockSpeed,Name,NumberOfCores,NumberOfLogicalProcessors,SocketDesignation FROM Win32_Processor";

        private IWmiContext _context;

        private IList<Processor> _Processors;

        public WmiSystemInfoProvider(IWmiContext context)
        {
            this._context = context;
        }

        public IList<Processor> Processors
        {
            get 
            {
                if (this._Processors == null)
                {
                    var processors = new List<Processor>();
                    processors.AddRange(this.GetProcessorInfo());
                    this._Processors = processors;
                }

                return this._Processors;
            }
        }

        private IEnumerable<Processor> GetProcessorInfo()
        {
            var processors = this._context.Query<Processor>(ProcessorQuery, mo => new Processor()
            {
                Architecture = mo.GetPropertyValueOrDefault<ushort>("Architecture", (ushort)ArchitectureType.None),
                DeviceId = mo.GetPropertyValueOrDefault<string>("DeviceID", string.Empty),
                L2CacheSizeKBs = mo.GetPropertyValueOrDefault<ushort>("L2CacheSize", 0),
                L3CacheSizeKBs = mo.GetPropertyValueOrDefault<ushort>("L3CacheSize", 0),
                Manufacturer = mo.GetPropertyValueOrDefault<string>("Manufacturer", string.Empty),
                MaxClockSpeedMHz = mo.GetPropertyValueOrDefault<ushort>("MaxClockSpeed", 0),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                NumberOfCores = mo.GetPropertyValueOrDefault<ushort>("NumberOfCores", 0),
                NumberOfLogicalProcessors = mo.GetPropertyValueOrDefault<ushort>("NumberOfLogicalProcessors", 0),
                Socket = mo.GetPropertyValueOrDefault<string>("SocketDesignation", string.Empty)
            });

            return processors;
        }
    }
}
