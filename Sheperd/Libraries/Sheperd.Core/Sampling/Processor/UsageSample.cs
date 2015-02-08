﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling.Processor
{
    public class UsageSample : IInstancedSample
    {
        public DateTime Time { get; set; }
        public string Instance { get; set; }
        public float PercentProcessorTime { get; set; }
        public float PercentPrivilegedTime { get; set; }
    }
}
