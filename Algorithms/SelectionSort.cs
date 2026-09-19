using Sorting_Alg_Visualizer.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public class SelectionSort : IAlgorithm
    {
        public string Name { get; set; }
        private int minIndex, i, temp;
        private int j = 1;
        public SelectionSort()
        {
            Name = "Selectionsort";
        }
        public void Reset()
        {
            j = 1;
            i = 0;
        }

        public void Setup(ObservableCollection<int> sortSet)
        {
            minIndex = sortSet[i];
            j = 1;
            i = 0;
        }

        public bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
            activeValue.Index++;
            if(i == sortSet.Count -1 )
            {
                return true;
            }
            if(activeValue.Index == sortSet.Count)
            {
                temp = sortSet[i];
                sortSet[i] = sortSet[minIndex];
                sortSet[minIndex] = temp;
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
