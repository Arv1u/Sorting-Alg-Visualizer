using Avalonia.Markup.Xaml.Templates;
using Sorting_Alg_Visualizer.Util;
using System.Collections.ObjectModel;


namespace Sorting_Alg_Visualizer.Algorithms
{
    public class InsertionSort : IAlgorithm
    {
        public string Name { get; set; } = "Insertion Sort";
        private int j,i,key,n;
        bool sorting = false;

        public void Reset()
        {
            i = 0;
            j = 0;
            sorting = false;
        }

        public void Setup(ObservableCollection<int> sortSet)
        {
        }

        public bool Step(ObservableCollection<int> arr, ActiveValue activeValue)
        {
            n = arr.Count;

            if(sorting && j >= 0 && arr[j] > key)
            {
                //swap i and j
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;

                j--;
                activeValue.Index = j + 1;

                return false;
            }

            i++;
            if (i >= n)
            {
                activeValue.Index = -1;
                return true;
            }
            key = arr[i];
            j = i - 1;
            sorting = true;
            activeValue.Index = i;
            return false;
        }
    }
}
