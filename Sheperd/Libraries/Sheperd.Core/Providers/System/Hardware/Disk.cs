using System;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class Disk
    {
        public string DeviceID { get; set; }
        public string FirmwareRevision { get; set; }
        public string InstallDate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public UInt32 Partitions { get; set; }
        public string SerialNumber { get; set; }
        public UInt64 Size { get; set; }
        public string Status { get; set; }
    }
}
