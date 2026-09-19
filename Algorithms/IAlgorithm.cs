using Sorting_Alg_Visualizer.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public interface IAlgorithm
    {
        public string Name { get; set; }
        public void Setup(ObservableCollection<int> sortSet);
        public bool Step(ObservableCollection<int> sortSet,ActiveValue activeValue);
        public void Reset();
    }
}
