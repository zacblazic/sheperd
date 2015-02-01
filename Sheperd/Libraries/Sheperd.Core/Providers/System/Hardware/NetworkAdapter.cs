using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class NetworkAdapter
    {
        public string AdapterType { get; set; }
        public string ConnectionGuid { get; set; }
        public string DeviceId { get; set; }
        public ushort InterfaceIndex { get; set; }
        public string MacAddress { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
    }
}
