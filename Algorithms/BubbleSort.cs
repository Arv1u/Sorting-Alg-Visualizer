using Sorting_Alg_Visualizer.Util;
using System.Collections.ObjectModel;

namespace Sorting_Alg_Visualizer.Algorithms
{
    public class BubbleSort : Algorithm
    {
        int index = 0;
        int streak = 0;
        public BubbleSort()
        {
            Name = "Bubblesort";
        }
        public override void Setup(ObservableCollection<int> sortSet)
        {
            index = 0;
            streak = 0;
        }

        public override bool Step(ObservableCollection<int> sortSet, ActiveValue activeValue)
        {
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
                SwapValues(sortSet, activeValue.Index, activeValue.Index + 1);
            }
            else
            {
                streak++;
            }

            activeValue.Index++;

            return false;
        }
        public override void Reset()
        {
            index = 0;
        }
    }
}
