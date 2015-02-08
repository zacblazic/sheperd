using Sheperd.Core.Providers.System.Hardware;
using Sheperd.Core.Providers.System.Software;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers.System
{
    public interface ISystemInfoProvider
    {
        IList<Processor> Processors { get; }
        IList<Memory> MemoryModules { get; }
        Motherboard Motherboard { get; }
        IList<Disk> Disks { get; }
        IList<NetworkAdapter> NetworkAdapters { get; }
        IList<VideoCard> VideoCards { get; }

        IList<Driver> Drivers { get; }
    }
}
