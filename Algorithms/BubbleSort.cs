using Sorting_Alg_Visualizer.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public class BubbleSort : IAlgorithm
    {
        public string Name { get ; set; }
        private bool swapped = true;
        private int temp;
        int index = 0;
        int streak = 0;
        public BubbleSort()
        {
            Name = "Bubblesort";
        }
        public void Setup(ObservableCollection<int> sortSet)
        {
            index = 0;
            streak = 0;
        }

        public bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
            if (sortSet.Count < 2)
                return false;
            if(streak >= sortSet.Count - 1)
            {
                activeValue.Index = -1;
                return true;
            }
            if(index > sortSet.Count - 2)
            {
                activeValue.Index = -1;
                return true;
            }

            if (activeValue.Index > sortSet.Count - 2 - index)
            {
                activeValue.Index = 0;
                streak = 0;
                index++;
                return false;
            }

            if (sortSet[activeValue.Index] > sortSet[activeValue.Index + 1])
            {
                temp = sortSet[activeValue.Index + 1];
                sortSet[activeValue.Index + 1] = sortSet[activeValue.Index];
                sortSet[activeValue.Index] = temp;
            }
            else
            {
                streak++;
            }

            activeValue.Index++;

            return false;
        }
        public void Reset()
        {
            index = 0;
            temp = 0;
        }
    }
}
