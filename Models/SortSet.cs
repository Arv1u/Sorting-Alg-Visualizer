using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sorting_Alg_Visualizer.Models
{
    public class SortSet
    {
        private int totalElements;
        public ObservableCollection<int> Elements { get; }
        public SortSet(int totalElements)
        {
            this.totalElements = totalElements;
            this.Elements = new ObservableCollection<int>();
            fillElements();
        }
        private void fillElements()
        {
            Random rand = new Random();
            for (int i = 0; i < totalElements; i++)
            {
                Elements.Add(i + 1);
            }
            for(int i = 0; i < totalElements; i++)
            {
                int j = rand.Next(0, totalElements);
                int temp = Elements[i];
                Elements[i] = Elements[j];
                Elements[j] = temp;
            }
        }
    }
}