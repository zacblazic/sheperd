using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers.System.Hardware
{
    public class Memory
    {
        public string Bank { get; set; }
        public ulong CapacityBytes { get; set; }
        public ushort DataWidthBits { get; set; }
        public ushort FormFactor { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public ushort SpeedMHz { get; set; }
        public ushort TotalWidthBits { get; set; }
    }
}
