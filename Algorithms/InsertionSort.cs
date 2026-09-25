using Sorting_Alg_Visualizer.Util;
using System.Collections.ObjectModel;


namespace Sorting_Alg_Visualizer.Algorithms
{
    public class InsertionSort : IAlgorithm
    {
        public string Name { get; set; } = "Insertion Sort";
        private int j,i,key;
        bool swapped = true;

        public void Reset()
        {
            i = 0;
            swapped = true;
        }

        public void Setup(ObservableCollection<int> sortSet)
        {
        }

        public bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
            if(i >= sortSet.Count)
            {
                return true;
            }
            if (swapped)
            {
                int key = sortSet[i];
                int j = i - 1;
                activeValue.Index = j;

            }


            if(j >= 0 && sortSet[j] > key)
            {
                sortSet[j + 1] = sortSet[j];
                j = j - 1;
                activeValue.Index = j;
            }
            else
            {
                activeValue.Index = j;

                sortSet[j + 1] = key;
                i++;
                swapped = true;
            }

            return false;
        }
    }
}
