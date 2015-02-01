using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class Processor
    {
        public ushort Architecture { get; set; }
        public string DeviceId { get; set; }
        public ushort L2CacheSizeKBs { get; set; }
        public ushort L3CacheSizeKBs { get; set; }
        public string Manufacturer { get; set; }
        public ushort MaxClockSpeedMHz { get; set; }
        public string Name { get; set; }
        public ushort NumberOfCores { get; set; }
        public ushort NumberOfLogicalProcessors { get; set; }
        public string Socket { get; set; }
    }
}
