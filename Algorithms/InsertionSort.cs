using Avalonia.Controls.Shapes;
using Sorting_Alg_Visualizer.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public class InsertionSort : IAlgorithm
    {
        public string Name { get; set; } = "Insertion Sort";
        private int j,i;

        public void Reset()
        {
        }

        public void Setup(ObservableCollection<int> sortSet)
        {
            i = 0;
        }

        public bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
            if(i >= sortSet.Count)
            {
                return true;
            }

                int key = sortSet[i];
                int j = i - 1;
            if ( j>= 0 && sortSet[j] > key)
            {
                sortSet[j + 1] = sortSet[j];
                j = j - 1;
                activeValue.Index = j;
            }

            sortSet[j + 1] = key;
            i++;
            
            return false;
        }
    }
}
