using Sorting_Alg_Visualizer.Util;
using System.Collections.ObjectModel;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public class SelectionSort : Algorithm
    {
        private int minIndex, i;
        public SelectionSort()
        {
            Name = "Selectionsort";
        }
        public override void Reset()
        {
            i = 0;
            minIndex = 0;
        }


        public override void Setup(ObservableCollection<int> sortSet)
        {
            i = 0;
            minIndex = 0;
        }

        public override bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
            activeValue.Index++;
            if(i == sortSet.Count -1 )
            {
                return true;
            }
            if(activeValue.Index == sortSet.Count)
            {
                SwapValues(sortSet, i, minIndex);

                i++;
                activeValue.Index = i;
                minIndex = i;
                return false;
            }
            if (sortSet[minIndex]> sortSet[activeValue.Index])
            {
                minIndex = activeValue.Index;
            }
            
          return false;
        }
    }
}
