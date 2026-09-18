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
using Avalonia.Threading;
namespace Sorting_Alg_Visualizer.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        ActiveValue ActiveValue { get; set; } = new();
        public CartesianChart BarChart { get; set; }
        public RelayCommand StartCommand { get; }
        public RelayCommand PauseCommand { get; }
        public RelayCommand ResetCommand { get; }
        private static int defaultSetLength = 100;
        public ChartVM ChartVM { get; set; }
        private int stepsPerSecond;
        private readonly DispatcherTimer stepsTimer;
        public int StepsPerSecond
        {
            get
            {
                return stepsPerSecond;
            }
            set
            {
                stepsPerSecond = value;
                OnPropertyChanged(nameof(StepsPerSecond));
            }
        }
        private bool isRunning;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                UpdateTimerRunning(value);
                OnPropertyChanged(nameof(IsRunning));
            }
        }
        public MainWindowViewModel(CartesianChart barchart)
        {
            BarChart = barchart;

            ChartVM = new(new SortSet(defaultSetLength), ActiveValue);

            StartCommand = new(_ => StartAlgorithm());
            PauseCommand = new(_ => PauseAlgorithm());
            ResetCommand = new(_ => ResetAlgorithm());


            stepsTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
                IsEnabled = false
            };
            stepsTimer.Tick += RunTimestep;
        }
        private void RunTimestep(object? sender, EventArgs e)
        {
            ActiveValue.Index++;
            UpdateChart();
        }
        private void UpdateChart()
        {
            BarChart.CoreChart.Update(new ChartUpdateParams
            {
                IsAutomaticUpdate = false,
                Throttling = false
            });
        }
        private void StartAlgorithm()
        {
            IsRunning = true;
        }
        private void PauseAlgorithm()
        {
            IsRunning = false;
        }

        private void ResetAlgorithm()
        {
            IsRunning = false;

        }
        private void UpdateTimerRunning(bool isRunning)
        {
            stepsTimer.IsEnabled = isRunning;
        }
    }
}
