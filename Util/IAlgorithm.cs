using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_Alg_Visualizer.Util
{
    public interface IAlgorithm
    {
        public string Name { get; set; }
        public void Setup();
        public void Step();
    }
}
