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
using System.Security;
namespace Sorting_Alg_Visualizer.ViewModels;

public partial class ChartVM
{
    public ActiveValue ActiveValue{ get;}
    public int MyProperty { get; set; }
    public SortSet Values { get; }
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
    public ChartVM(SortSet set, ActiveValue activeValue)
    {
        this.Values = set;
        this.ActiveValue = activeValue;
        PointMeasuredCommand = new RelayCommand(point => OnPointMeasured((ChartPoint)point));
    }
    public RelayCommand PointMeasuredCommand{ get; }

    private void OnPointMeasured(ChartPoint point)
    {
        if (point == null) return;
        if (point.Context.Visual is null) return;

        if(point.Index == ActiveValue.Index)
        {
            point.Context.Visual.Fill = new SolidColorPaint(SKColors.Red);
        }
        else
        {
            point.Context.Visual.Fill = new SolidColorPaint(SKColors.LightBlue);
        }
    }
}