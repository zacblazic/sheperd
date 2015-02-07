using Sheperd.Core.Providers.System.Hardware;
using Sheperd.Core.Providers.System.Software;
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
        private const string MemoryQuery = "SELECT BankLabel,Capacity,DataWidth,FormFactor,Name,PartNumber,Speed,TotalWidth FROM Win32_PhysicalMemory";
        private const string MotherboadQuery = "SELECT Manufacturer,Model,Name,Product,Version FROM Win32_BaseBoard";
        private const string BiosQuery = "SELECT BiosCharacteristics,BiosVersion,InstallDate,Manufacturer,Name,ReleaseDate,SerialNumber,SMBIOSBIOSVersion,Status,Version FROM Win32_Bios";
        private const string DiskQuery = "SELECT DeviceID,FirmwareRevision,InstallDate,Manufacturer,Model,Name,Partitions,SerialNumber,Size,Status FROM Win32_DiskDrive";
        private const string NetworkAdapterQuery = "SELECT AdapterType,DeviceID,GUID,InterfaceIndex,MACAddress,Manufacturer,Name FROM Win32_NetworkAdapter WHERE PhysicalAdapter = TRUE";
        private const string VideoCardQuery = "SELECT Description,Name,DriverDate,DriverVersion,Status,CurrentRefreshRate,CurrentHorizontalResolution,CurrentVerticalResolution,InstalledDisplayDrivers FROM Win32_VideoController";

        private const string DriverQuery = "SELECT AcceptPause,AcceptStop,Description,DisplayName,Name,PathName,Started,StartMode,StartName,State,Status FROM Win32_SystemDriver";

        private IWmiContext _context;

        private IList<Processor> _Processors;
        private IList<Memory> _MemoryModules;
        private Motherboard _Motherboard;
        private IList<Disk> _Disks;
        private IList<NetworkAdapter> _NetworkAdapters;
        private IList<VideoCard> _VideoCards;

        private IList<Driver> _Drivers;

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
                    this._Processors = this.GetProcessorInfo().ToList();
                }

                return this._Processors;
            }
        }

        public Motherboard Motherboard
        {
            get
            {
                if (this._Motherboard == null)
                {
                    this._Motherboard = this.GetMotherboardInfo();
                }

                return this._Motherboard;
            }
        }

        public IList<Memory> MemoryModules
        {
            get
            {
                if (this._MemoryModules == null)
                {
                    this._MemoryModules = this.GetMemoryModules().ToList();
                }

                return this._MemoryModules;
            }
        }

        public IList<Disk> Disks
        {
            get
            {
                if (this._Disks == null)
                {
                    this._Disks = this.GetDiskInfo().ToList();
                }

                return this._Disks;
            }
        }

        public IList<NetworkAdapter> NetworkAdapters
        {
            get
            {
                if (this._NetworkAdapters == null)
                {
                    this._NetworkAdapters = this.GetNetworkAdapters().ToList();
                }

                return this._NetworkAdapters;
            }
        }

        public IList<VideoCard> VideoCards
        {
            get
            {
                if (this._VideoCards == null)
                {
                    this._VideoCards = this.GetVideoCards().ToList();
                }

                return this._VideoCards;
            }
        }

        public IList<Driver> Drivers
        {
            get
            {
                if(this._Drivers == null)
                {
                    this._Drivers = this.GetDrivers().ToList();
                }

                return this._Drivers;
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

        private IEnumerable<Memory> GetMemoryModules()
        {
            var memoryModules = this._context.Query(MemoryQuery, mo => new Memory()
            {
                Bank = mo.GetPropertyValueOrDefault<string>("BankLabel", string.Empty),
                CapacityBytes = mo.GetPropertyValueOrDefault<ulong>("Capacity", 0),
                DataWidthBits = mo.GetPropertyValueOrDefault<ushort>("DataWidth", 0),
                FormFactor = mo.GetPropertyValueOrDefault<ushort>("FormFactor", 0),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                PartNumber = mo.GetPropertyValueOrDefault<string>("PartNumber", string.Empty),
                SpeedMHz = mo.GetPropertyValueOrDefault<ushort>("Speed", 0),
                TotalWidthBits = mo.GetPropertyValueOrDefault<ushort>("TotalWidth", 0)
            });

            return memoryModules;
        }

        private Motherboard GetMotherboardInfo()
        {
            var motherboard = this._context.Query<Motherboard>(MotherboadQuery, mo => new Motherboard()
            {
                Manufacturer = mo.GetPropertyValueOrDefault<string>("Manufacturer", string.Empty),
                Model = mo.GetPropertyValueOrDefault<string>("Model", string.Empty),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                Product = mo.GetPropertyValueOrDefault<string>("Product", string.Empty),
                Version = mo.GetPropertyValueOrDefault<string>("Version", string.Empty)
            }).FirstOrDefault();

            if (motherboard != null)
            {
                motherboard.Bios = this._context.Query<Bios>(BiosQuery, mo => new Bios()
                {
                    BiosCharacteristics = mo.GetPropertyValueOrDefault<UInt16[]>("BiosCharacteristics", null),
                    BiosVersion = mo.GetPropertyValueOrDefault<string[]>("BiosVersion", null),
                    InstallDate = mo.GetPropertyValueOrDefault<string>("InstallDate", string.Empty),
                    Manufacturer = mo.GetPropertyValueOrDefault<string>("Manufacturer", string.Empty),
                    Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                    ReleaseDate = mo.GetPropertyValueOrDefault<string>("ReleaseDate", string.Empty),
                    SerialNumber = mo.GetPropertyValueOrDefault<string>("SerialNumber", string.Empty),
                    SMBIOSBIOSVersion = mo.GetPropertyValueOrDefault<string>("SMBIOSBIOSVersion", string.Empty),
                    Status = mo.GetPropertyValueOrDefault<string>("Status", string.Empty),
                    Version = mo.GetPropertyValueOrDefault<string>("Version", string.Empty)
                }).FirstOrDefault();
            }

            return motherboard;
        }

        private IEnumerable<Disk> GetDiskInfo()
        {
            var disks = this._context.Query<Disk>(DiskQuery, mo => new Disk()
            {
                DeviceID = mo.GetPropertyValueOrDefault<string>("DeviceID", string.Empty),
                FirmwareRevision = mo.GetPropertyValueOrDefault<string>("FirmwareRevision", string.Empty),
                InstallDate = mo.GetPropertyValueOrDefault<string>("InstallDate", string.Empty),
                Manufacturer = mo.GetPropertyValueOrDefault<string>("Manufacturer", string.Empty),
                Model = mo.GetPropertyValueOrDefault<string>("Model", string.Empty),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                Partitions = mo.GetPropertyValueOrDefault<UInt32>("Partitions", 0),
                SerialNumber = mo.GetPropertyValueOrDefault<string>("SerialNumber", string.Empty),
                Size = mo.GetPropertyValueOrDefault<UInt64>("Size", 0),
                Status = mo.GetPropertyValueOrDefault<string>("Status", string.Empty)
            });

            return disks;
        }

        private IEnumerable<NetworkAdapter> GetNetworkAdapters()
        {
            var adapters = this._context.Query<NetworkAdapter>(NetworkAdapterQuery, mo => new NetworkAdapter()
            {
                AdapterType = mo.GetPropertyValueOrDefault<string>("AdapterType", string.Empty),
                ConnectionGuid = mo.GetPropertyValueOrDefault<string>("GUID", string.Empty),
                DeviceId = mo.GetPropertyValueOrDefault<string>("DeviceID", string.Empty),
                InterfaceIndex = mo.GetPropertyValueOrDefault<ushort>("InterfaceIndex", 0),
                MacAddress = mo.GetPropertyValueOrDefault<string>("MACAddress", string.Empty),
                Manufacturer = mo.GetPropertyValueOrDefault<string>("Manufacturer", string.Empty),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty)
            });

            return adapters;
        }

        private IEnumerable<VideoCard> GetVideoCards()
        {
            var videoCards = this._context.Query<VideoCard>(VideoCardQuery, mo => new VideoCard()
            {
                Description = mo.GetPropertyValueOrDefault<string>("Description", string.Empty),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                InstalledDisplayDrivers = mo.GetPropertyValueOrDefault<string>("InstalledDisplayDrivers", string.Empty),
                DriverVersion = mo.GetPropertyValueOrDefault<string>("DriverVersion", string.Empty),
                DriverDate = mo.GetPropertyValueOrDefault<string>("DriverDate", string.Empty),
                CurrentHorizontalResolution = mo.GetPropertyValueOrDefault<UInt32>("CurrentHorizontalResolution", 0),
                CurrentVerticalResolution = mo.GetPropertyValueOrDefault<UInt32>("CurrentVerticalResolution", 0),
                CurrentRefreshRate = mo.GetPropertyValueOrDefault<UInt32>("CurrentRefreshRate", 0),
                Status = mo.GetPropertyValueOrDefault<string>("Status", string.Empty)
            });

            return videoCards;
        }

        private IEnumerable<Driver> GetDrivers()
        {
            var drivers = this._context.Query<Driver>(DriverQuery, mo => new Driver()
            {
                AcceptPause = mo.GetPropertyValueOrDefault<bool>("AcceptPause", false),
                AcceptStop = mo.GetPropertyValueOrDefault<bool>("AcceptStop", false),
                Description = mo.GetPropertyValueOrDefault<string>("Description", string.Empty), 
                DisplayName = mo.GetPropertyValueOrDefault<string>("DisplayName", string.Empty),
                Name = mo.GetPropertyValueOrDefault<string>("Name", string.Empty),
                PathName = mo.GetPropertyValueOrDefault<string>("PathName", string.Empty),
                Started = mo.GetPropertyValueOrDefault<bool>("Started", false),
                StartMode = mo.GetPropertyValueOrDefault<string>("StartMode", string.Empty),
                StartName = mo.GetPropertyValueOrDefault<string>("StartName", string.Empty),
                State = mo.GetPropertyValueOrDefault<string>("State", string.Empty),
                Status = mo.GetPropertyValueOrDefault<string>("Status", string.Empty)
            });

            return drivers;
        }
    }
}
