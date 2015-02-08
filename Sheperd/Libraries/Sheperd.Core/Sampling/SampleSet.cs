using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Sampling
{
    public class SampleSet : ISampleSet
    {
        private readonly List<ISample> _samples = new List<ISample>();

        public int Count
        {
            get
            {
                return this._samples.Count();
            }
        }

        public SampleSet()
        {
        }

        public SampleSet(params ISample[] samples)
        {
            this._samples.AddRange(samples);
        }

        public SampleSet(IEnumerable<ISample> samples)
        {
            this._samples.AddRange(samples);
        }

        public void Add(ISample sample)
        {
            this._samples.Add(sample);
        }

        public IEnumerator<ISample> GetEnumerator()
        {
            return this._samples.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
