using System;
using Waves.Core.Base;
using Waves.Core.Services.Interfaces;
using Waves.Presentation.Base;
using Waves.UI.Drawing.Charting.Base;
using Waves.UI.Drawing.Charting.Base.Enums;
using Waves.UI.Drawing.Charting.Presentation;
using Waves.UI.Drawing.Charting.Presentation.Interfaces;
using Waves.UI.Drawing.Charting.Services.Interfaces;
using Waves.UI.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Drawing.Services.Interfaces;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public ChartingTabViewModel(Core core) : base(core)
        {
        }

        /// <summary>
        ///     Gets drawing service.
        /// </summary>
        public IDrawingService DrawingService { get; private set; }

        /// <summary>
        /// Gets charting service.
        /// </summary>
        public IChartingService ChartingService { get; private set; }

        /// <summary>
        ///     Gets themes service.
        /// </summary>
        public IThemeService ThemeService { get; private set; }

        /// <summary>
        ///     Gets input service.
        /// </summary>
        public IInputService InputService { get; private set; }

        /// <summary>
        ///     Gets drawing element presentation.
        /// </summary>
        public IChartPresentation ChartPresentation { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DrawingService = Core.GetService<IDrawingService>();
            ThemeService = Core.GetService<IThemeService>();
            InputService = Core.GetService<IInputService>();
            ChartingService = Core.GetService<IChartingService>();

            ChartPresentation = new DataSetChartPresentation(DrawingService, ThemeService, InputService, ChartingService.GetChartViewFactory());
            
            ChartPresentation.Initialize();

            var context = ChartPresentation.DataContext as IDataSetChartViewModel;
            if (context == null) return;

            context.Update();

            var num1 = 1024;
            var random1 = new Random();
            var points1 = new Point[num1];

            for (var i = 0; i < num1; i++)
            {
                points1[i].X = i / (float) num1;
                points1[i].Y = (float) random1.NextDouble() - 0.5f;
            }

            var dataSet1 = new DataSet(points1)
            {
                Color = ThemeService.SelectedTheme.MiscellaneousColorSet.GetColor("Success-Color"),
                Type = DataSetType.BarWithEnvelope, Opacity = 0.75f
            };
            context.AddDataSet(dataSet1);

            //var num2 = 65536;
            //var random2 = new Random();
            //var points2 = new Point[num2];
            //for (var i = 0; i < num2; i++)
            //{
            //    points2[i].X = i / (float)num2;
            //    points2[i].Y = (float)random2.NextDouble() - 0.5f;
            //}

            //var dataSet2 = new DataSet(points2) { Color = ThemeService.SelectedTheme.MiscellaneousColorSet.GetColor("Error-Color"), Type = DataSetType.BarWithEnvelope, Opacity = 0.75f };
            //context.AddDataSet(dataSet2);

            //var num3 = 65536;
            //var random3 = new Random();
            //var points3 = new Point[num3];
            //for (var i = 0; i < num3; i++)
            //{
            //    points3[i].X = i / (float)num3;
            //    points3[i].Y = (float)Math.Sin(i) * (float)random3.NextDouble() - 0.5f;
            //}

            //var dataSet3 = new DataSet(points3) { Color = ThemeService.SelectedTheme.MiscellaneousColorSet.GetColor("Warning-Color"), Type = DataSetType.BarWithEnvelope, Opacity = 0.75f };
            //context.AddDataSet(dataSet3);
        }
    }
}