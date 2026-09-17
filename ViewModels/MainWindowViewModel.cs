using System;
using System.Collections.Generic;
using System.Text;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Avalonia;
using Sorting_Alg_Visualizer.Models;
using Sorting_Alg_Visualizer.MVVM;
using Sorting_Alg_Visualizer.Util;
using Sorting_Alg_Visualizer.ViewModels;
using LiveChartsCore.Kernel;
namespace Sorting_Alg_Visualizer.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        ActiveValue ActiveValue { get; set; } = new();
        public CartesianChart BarChart { get; set; }
        public RelayCommand TestCommand { get; }
        private static int defaultSetLength = 100;
        public ChartVM ChartVM { get; set; }
        public MainWindowViewModel(CartesianChart barchart)
        {
            BarChart = barchart;

            ChartVM = new(new SortSet(defaultSetLength), ActiveValue);

            TestCommand = new(_ => IncreaseActiveValue());
        }
        private void IncreaseActiveValue()
        {
            ActiveValue.Index++;
            BarChart.CoreChart.Update(new ChartUpdateParams
            {
                IsAutomaticUpdate = false,
                Throttling = false
            });
        }
    }
    
}
