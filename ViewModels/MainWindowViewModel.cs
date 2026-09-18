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
using System.Threading;
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
        private decimal sortLength;
        public decimal SortLength
        {
            get
            {
                return sortLength;
            }
            set
            {
                sortLength = value;
                OnPropertyChanged(nameof(SortLength));
            }
        }
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
                UpdateTimerSpeed(value);
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


            StartCommand = new(_ => StartAlgorithm());
            PauseCommand = new(_ => PauseAlgorithm());
            ResetCommand = new(_ => ResetAlgorithm());

            stepsTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
                IsEnabled = false
            };
            stepsTimer.Tick += RunTimestep;
            StepsPerSecond = 1;
            SortLength = 100;
            CreateNewChart((int)SortLength);

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
            ActiveValue.Index = 0;
            ChartVM.Values.totalElements = (int)SortLength;
            ChartVM.Values.FillElements();
            UpdateChart();
        }
        private void UpdateTimerRunning(bool isRunning)
        {
            stepsTimer.IsEnabled = isRunning;
        }
        private void UpdateTimerSpeed(int stepsPerSecond)
        {
            stepsTimer.Interval = TimeSpan.FromMilliseconds(1000.0 / stepsPerSecond);
        }
        private void CreateNewChart(int length)
        {
            ChartVM = new((int)length, ActiveValue);
        }
    }
}
