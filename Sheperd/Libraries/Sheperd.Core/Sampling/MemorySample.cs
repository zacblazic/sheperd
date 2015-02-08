using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling
{
    public class MemorySample : ISample
    {
        public DateTime Time { get; set; }
        public string Instance { get; set; }

        public ulong AvailableBytes { get; set; }
        public ulong CommitLimit { get; set; }
        public ulong CommitBytes { get; set; }
        public ulong CachedBytes { get; set; }
        public ulong PoolPagedBytes { get; set; }
        public ulong PoolNonPagedBytes { get; set; }
    }
}
