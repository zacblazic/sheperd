using Sheperd.Core.Providers.System.Hardware;
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
        private const string MotherboadQuery = "SELECT Manufacturer,Model,Name,Product,Version FROM Win32_BaseBoard";
        private const string BiosQuery = "SELECT BiosCharacteristics,BiosVersion,InstallDate,Manufacturer,Name,ReleaseDate,SerialNumber,SMBIOSBIOSVersion,Status,Version FROM Win32_Bios";
        private const string DiskQuery = "SELECT DeviceID,FirmwareRevision,InstallDate,Manufacturer,Model,Name,Partitions,SerialNumber,Size,Status FROM Win32_DiskDrive";

        private IWmiContext _context;

        private IList<Processor> _Processors;
        private Motherboard _Motherboard;
        private IList<Disk> _Disks;

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
                    var processors = new List<Processor>();
                    processors.AddRange(this.GetProcessorInfo());
                    this._Processors = processors;
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
                    var motherboard = this.GetMotherboardInfo();
                    this._Motherboard = motherboard;
                }

                return this._Motherboard;
            }
        }

        public IList<Disk> Disks
        {
            get
            {
                if (this._Disks == null)
                {
                    var disks = new List<Disk>();
                    disks.AddRange(this.GetDiskInfo());
                    this._Disks = disks;
                }

                return this._Disks;
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
    }
}