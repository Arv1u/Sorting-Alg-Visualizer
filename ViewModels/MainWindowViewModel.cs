using System;
using System.Collections.Generic;
using System.Text;
using Sorting_Alg_Visualizer.Models;
using Sorting_Alg_Visualizer.Util;
using Sorting_Alg_Visualizer.ViewModels;

namespace Sorting_Alg_Visualizer.ViewModels
{
    public class MainWindowViewModel
    {
        ActiveValue ActiveValue { get; set; } = new();
        private static int defaultSetLength = 100;
        public ChartVM ChartVM { get; set; }
        public MainWindowViewModel()
        {
            ChartVM = new(new SortSet(defaultSetLength), ActiveValue);
        }
    }
    
}
