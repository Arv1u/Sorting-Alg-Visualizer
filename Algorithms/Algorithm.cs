using Sorting_Alg_Visualizer.Util;
using System.Collections.ObjectModel;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public abstract class Algorithm
    {
        public string? Name { get; protected set; }
        public string? Description { get; protected set; }
        public string? TimeComplexity { get; protected set; }
        public string? AuxiliarySpace { get; protected set; }
        public bool? IsStable { get; protected set; }
        public string? ExampleCode { get; protected set; }
        public abstract void Setup(ObservableCollection<int> sortSet);
        public abstract bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue);
        public abstract void Reset();
        protected static void SwapValues(ObservableCollection<int> list, int key1, int key2)
        {
            int temp = list[key1];
            list[key1] = list[key2];
            list[key2] = temp;
        }
    }
}