using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling
{
    public class InstancedSample : IInstancedSample
    {
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Instance { get; set; }
        public float Value { get; set; }
    }
}
