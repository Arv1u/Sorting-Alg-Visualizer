using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using Sorting_Alg_Visualizer.Models;
namespace Sorting_Alg_Visualizer.ViewModels;

public class ChartVM
{
    public ISeries[] Series { get; set; } = [
        new ColumnSeries<int>(),
        new ColumnSeries<int>(4, 2, 6),
        new ColumnSeries<double, DiamondGeometry>(4, 3, 4)
    ];
}