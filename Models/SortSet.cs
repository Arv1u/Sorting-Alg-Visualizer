using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sorting_Alg_Visualizer.Models
{
    public class SortSet
    {
        public int totalElements;
        public ObservableCollection<int> Elements { get; set; }
        public SortSet(int totalElements)
        {
            this.totalElements = totalElements;
            this.Elements = new ObservableCollection<int>();
            FillElements();
        }
        public void FillElements()
        {
            Random rand = new Random();
            Elements.Clear();
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