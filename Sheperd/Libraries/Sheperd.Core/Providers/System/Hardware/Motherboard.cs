using System;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class Motherboard
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public Bios Bios { get; set; }
    }

    public class Bios
    {
        public UInt16[] BiosCharacteristics { get; set; }
        public string[] BiosVersion { get; set; }
        public string InstallDate { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string SerialNumber { get; set; }
        public string SMBIOSBIOSVersion { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
    }
}
