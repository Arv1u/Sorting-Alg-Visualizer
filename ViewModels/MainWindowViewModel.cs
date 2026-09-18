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
using System.Collections.ObjectModel;
using Sorting_Alg_Visualizer.Algorithms;
namespace Sorting_Alg_Visualizer.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        ActiveValue ActiveValue { get; set; } = new();
        public CartesianChart BarChart { get; set; }
        public RelayCommand StartCommand { get; }
        public RelayCommand PauseCommand { get; }
        public RelayCommand ResetCommand { get; }
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
        public ObservableCollection<IAlgorithm> Algorithms { get; set; } = new();
        private IAlgorithm selectedAlgorithm;
        public IAlgorithm SelectedAlgorithm
        {
            get
            {
                return selectedAlgorithm;
            }
            set
            {
                selectedAlgorithm = value;
                OnPropertyChanged(nameof(SelectedAlgorithm));
            }
        }
        private bool isReset = true;
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

            SetupAlgorithms();
        }
        private void RunTimestep(object? sender, EventArgs e)
        {
            SelectedAlgorithm.Step();
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
            if (isReset)
            {
                SelectedAlgorithm.Setup();
            }
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

        private void SetupAlgorithms()
        {
            Algorithms.Add(new BubbleSort());
        }
    }
}
