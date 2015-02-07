using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class VideoCard
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string DriverDate { get; set; }
        public string DriverVersion { get; set; }
        public string Status { get; set; }
        public UInt32 CurrentRefreshRate { get; set; }
        public UInt32 CurrentHorizontalResolution { get; set; }
        public UInt32 CurrentVerticalResolution { get; set; }
        public string InstalledDisplayDrivers { get; set; }
    }
}
