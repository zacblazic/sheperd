using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers.System.Hardware
{
    public enum ArchitectureType
    {
        x86 = 0,
        MIPS = 1,
        Alpha = 2,
        PowerPC = 3,
        ARM = 5,
        Itanium = 6,
        x64 = 9,
        None = 999
    }
}
