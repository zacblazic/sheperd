using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling
{
    public interface ISampleSet : IEnumerable<ISample>, IEnumerable
    {
        int Count { get; }
        void Add(ISample sample);
    }
}
