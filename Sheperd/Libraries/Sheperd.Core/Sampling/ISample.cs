using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling
{
    public interface ISample
    {
        DateTime Time { get; }
        string Instance { get; }
    }
}
