using System;
using System.Collections.Generic;

namespace Sheperd.Core.Providers.System.Hardware
{
    public static class BiosCharacteristics
    {
        public static Dictionary<Func<int, bool>, string> BiosCodes
        {
            get
            {
                return new Dictionary<Func<int, bool>, string>
                {
                    { d => d == 0 || d == 1, "Reserved" },
                    { d => d == 2, "Unknown"},
                    { d => d == 3, "BIOS Characteristics Not Supported"},
                    { d => d == 4, "ISA is supported"},
                    { d => d == 5, "MCA is supported"},
                    { d => d == 6, "EISA is supported"},
                    { d => d == 7, "PCI is supported"},
                    { d => d == 8, "PC Card(PCMCIA) is supported"},
                    { d => d == 9, "Plug and Play is supported"},
                    { d => d == 10, "APM is supported"},
                    { d => d == 11, "BIOS is Upgradable(Flash)"},
                    { d => d == 12, "BIOS shadowing is allowed"},
                    { d => d == 13, "VL - VESA is supported"},
                    { d => d == 14, "ESCD support is available"},
                    { d => d == 15, "Boot from CD is supported"},
                    { d => d == 16, "Selectable Boot is supported"},
                    { d => d == 17, "BIOS ROM is socketed"},
                    { d => d == 18, "Boot From PC Card(PCMCIA) is supported"},
                    { d => d == 19, "EDD(Enhanced Disk Drive) Specification is supported"},
                    { d => d == 20, "Int 13h - Japanese Floppy for NEC 9800 1.2mb(3.5, 1k Bytes / Sector, 360 RPM) is supported"},
                    { d => d == 21, "Int 13h - Japanese Floppy for Toshiba 1.2mb(3.5, 360 RPM) is supported"},
                    { d => d == 22, "Int 13h - 5.25 / 360 KB Floppy Services are supported"},
                    { d => d == 23, "Int 13h - 5.25 / 1.2MB Floppy Services are supported"},
                    { d => d == 24, "Int 13h - 3.5 / 720 KB Floppy Services are supported"},
                    { d => d == 25, "Int 13h - 3.5 / 2.88 MB Floppy Services are supported"},
                    { d => d == 26, "Int 5h, Print Screen Service is supported"},
                    { d => d == 27, "Int 9h, 8042 Keyboard services are supported"},
                    { d => d == 28, "Int 14h, Serial Services are supported"},
                    { d => d == 29, "Int 17h, printer services are supported"},
                    { d => d == 30, "Int 10h, CGA / Mono Video Services are supported"},
                    { d => d == 31, "NEC PC - 98"},
                    { d => d == 32, "ACPI is supported"},
                    { d => d == 33, "USB Legacy is supported"},
                    { d => d == 34, "AGP is supported"},
                    { d => d == 35, "I2O boot is supported"},
                    { d => d == 36, "LS - 120 boot is supported"},
                    { d => d == 37, "ATAPI ZIP Drive boot is supported"},
                    { d => d == 38, "1394 boot is supported"},
                    { d => d == 39, "Smart Battery is supported"},
                    { d => d >= 40 && d <= 47, "Reserved for BIOS vendor"},
                    { d => d >= 48 && d <= 63, "Reserved for system vendor"}
                };
            }
        }
    }
}

