using Avalonia.Threading;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView.Avalonia;
using Sorting_Alg_Visualizer.Algorithms;
using Sorting_Alg_Visualizer.MVVM;
using Sorting_Alg_Visualizer.Util;
using System;
using System.Collections.ObjectModel;
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
        private static readonly int sortLengthDefault = 10;
        public decimal SortLength
        {
            get;
            set
            {
                field = value;
                if(SelectedAlgorithm != null)
                ResetAlgorithm();
                OnPropertyChanged(nameof(SortLength));
            }
        } = sortLengthDefault;

        private DispatcherTimer stepsTimer;
        private static int stepsPerSecondDefault = 1;
        public int StepsPerSecond
        {
            get;
            set
            {
                field = value;
                UpdateTimerSpeed(value);
                OnPropertyChanged(nameof(StepsPerSecond));
            }
        } = stepsPerSecondDefault;
        private Algorithm selectedAlgorithm;
        public Algorithm SelectedAlgorithm
        {
            get
            {
                return selectedAlgorithm;
            }
            set
            {
                selectedAlgorithm = value;
                OnPropertyChanged(nameof(SelectedAlgorithm));
                if (isReset)
                {
                    ResetAlgorithm();
                    isReset = false;
                }
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
        public ObservableCollection<Algorithm> Algorithms { get; set; } = new();
        private bool isReset = true;

        public MainWindowViewModel(CartesianChart barchart)
        {
            BarChart = barchart;
            ChartVM = new((int)10, ActiveValue);

            StartCommand = new(_ => StartAlgorithm());
            PauseCommand = new(_ => PauseAlgorithm());
            ResetCommand = new(_ => ResetAlgorithm());

            SetupTimer();
            StepsPerSecond = 1;
            SortLength = 10;
            ActiveValue.Index = 0;
            SetupAlgorithms();
        }
        private void SetupTimer()
        {
            stepsTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
                IsEnabled = false
            };
            stepsTimer.Tick += RunTimestep;
        }
        private void RunTimestep(object? sender, EventArgs e)
        {
            if (SelectedAlgorithm.Step(ChartVM.Values.Elements, ActiveValue)&&IsRunning)
            {
                IsRunning = false;
                isReset = true;
            }
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
                SelectedAlgorithm.Setup(ChartVM.Values.Elements);
                ActiveValue.Index = 0;
                isReset = false;
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
            isReset = true;
            ActiveValue.Index = 0;
            ChartVM.Values.totalElements = (int)SortLength;
            ChartVM.Values.FillElements();
            SelectedAlgorithm.Reset();
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

        private void SetupAlgorithms()
        {
            Algorithms.Add(new BubbleSort());
            Algorithms.Add(new SelectionSort());
            Algorithms.Add(new InsertionSort());
            SelectedAlgorithm = Algorithms[0];
        }
    }
}