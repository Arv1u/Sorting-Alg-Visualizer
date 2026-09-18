using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Sorting_Alg_Visualizer.Models;
using Sorting_Alg_Visualizer.MVVM;
using Sorting_Alg_Visualizer.Util;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security;
namespace Sorting_Alg_Visualizer.ViewModels;

public partial class ChartVM : PropertyChangedBase
{
    public ActiveValue ActiveValue{ get;}
    private SolidColorPaint Red = new SolidColorPaint(SKColors.Red);
    private SolidColorPaint RLightBlue= new SolidColorPaint(SKColors.LightBlue);
    public SortSet Values { get; set; }
    public Axis[] XAxes { get; set; } = new Axis[]
    {
        new Axis
        {
            IsVisible = false
        }
    };
    public Axis[] YAxes { get; set; } = new Axis[]
    {
        new Axis
        {
            IsVisible = false
        }
    };
    public ChartVM(int length, ActiveValue activeValue)
    {
        this.Values = new SortSet(length);
        this.ActiveValue = activeValue;
        PointMeasuredCommand = new RelayCommand(point => OnPointMeasured((ChartPoint)point));
    }
    public RelayCommand PointMeasuredCommand{ get; set; }

    private void OnPointMeasured(ChartPoint point)
    {
        if (point == null) return;
        if (point.Context.Visual is null) return;

        if (point.Index == ActiveValue.Index)
        {
            point.Context.Visual.Fill = new SolidColorPaint(SKColors.Red);
        }
        else
        {
            point.Context.Visual.Fill = new SolidColorPaint(SKColors.LightBlue);

        }
    }
    public void NewSortSet(int length)
    {
        Values = new(10);

        PointMeasuredCommand = new RelayCommand(point => OnPointMeasured((ChartPoint)point));

    }
}