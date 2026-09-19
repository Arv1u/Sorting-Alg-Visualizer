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
        }

        public bool Step(ObservableCollection<int> sortSet,ActiveValue activeValue)
        {
            if(streak == sortSet.Count - 1)
            {
                return true;
            }
            if(activeValue.Index == sortSet.Count - 1)
            {
                activeValue.Index = 0;
                index++;
                Debug.WriteLine("Reset");
                return false;
            }
            if (sortSet[activeValue.Index] > sortSet[activeValue.Index + 1])
            {
                temp = sortSet[activeValue.Index + 1];
                sortSet[activeValue.Index + 1] = sortSet[activeValue.Index];
                sortSet[activeValue.Index] = temp;
                streak = 0;
                Debug.WriteLine("Swapped");
            }
            else
            { 
                streak++;
            }
            if (activeValue.Index == sortSet.Count - 1 - index)
            {
                activeValue.Index = 0;
                index++;
                Debug.WriteLine("Reset");
                streak = 0;
                return false;
            }
            Debug.WriteLine("--------------");
            Debug.WriteLine("Streak: " + streak);
            Debug.WriteLine("Index: " + index);
            Debug.WriteLine("--------------");
            activeValue.Index++;
            return false;
        } 
        public void Reset()
        {
            index = 0;
            streak = 0;
            temp = 0;
        }
    }
}
