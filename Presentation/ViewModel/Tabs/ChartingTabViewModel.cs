using System;
using System.Threading;
using System.Threading.Tasks;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.Base;
using Waves.UI.Drawing.Charting.Base;
using Waves.UI.Drawing.Charting.Base.Enums;
using Waves.UI.Drawing.Charting.Presentation;
using Waves.UI.Drawing.Charting.Presentation.Interfaces;
using Waves.UI.Drawing.Charting.Services.Interfaces;
using Waves.UI.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Drawing.Presentation;
using Waves.UI.Drawing.Presentation.Interfaces;
using Waves.UI.Drawing.Services.Interfaces;
using Waves.UI.Drawing.ViewModel.Interfaces;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public ChartingTabViewModel(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Charting Tab View Model";

        /// <summary>
        ///     Gets drawing service.
        /// </summary>
        public IDrawingService DrawingService { get; private set; }

        /// <summary>
        ///     Gets charting service.
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
        public IDrawingElementPresenter DrawingElementPresenter { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            try
            {
                base.Initialize();
            
                DrawingService = Core.GetInstance<IDrawingService>();
                ThemeService = Core.GetInstance<IThemeService>();
                InputService = Core.GetInstance<IInputService>();
                ChartingService = Core.GetInstance<IChartingService>();

                // DrawingElementPresenter = new DrawingElementPresenter(Core, DrawingService, InputService);
                // DrawingElementPresenter.Initialize();
                //
                // var context = DrawingElementPresenter.DataContext as IDrawingElementPresenterViewModel;
                // if (context == null)
                //     return;
                //
                // var obj = new Line()
                // {
                //     StrokeThickness = 1,
                //     Stroke = WavesColor.Black,
                //     Point1 = new WavesPoint(0, 0),
                //     Point2 = new WavesPoint(100, 100)
                // };
                //
                // context.AddDrawingObject(obj);

                // var task = new Task(() =>
                // {
                //     do
                //     {
                //         context.RemoveDrawingObject(obj);
                //         
                //         obj.Stroke = WavesColor.Random();
                //         
                //         context.AddDrawingObject(obj);
                //         
                //         context.Update();
                //         
                //         Thread.Sleep(50);
                //         
                //     } while (true);
                // });
                // task.Start();
                

                DrawingElementPresenter = new DatasetChartPresenter(
                    Core,
                    ChartingService.GetChartViewFactory());
                
                DrawingElementPresenter.MessageReceived += OnMessageReceived;
                
                DrawingElementPresenter.Initialize();
                
                var context = DrawingElementPresenter.DataContext as IDataSetChartPresenterViewModel;
                if (context == null) return;
                
                context.Update();
                
                var num1 = 128000 * 2;
                var random1 = new Random();
                var points1 = new WavesPoint[num1];
                
                for (var i = 0; i < num1; i++)
                {
                    points1[i].X = i / (float) num1;
                    points1[i].Y = (float) random1.NextDouble() - 0.5f;
                }
                
                var dataSet1 = new DataSet(points1)
                {
                    // Color = WavesColor.Red,
                    Type = DataSetType.Line, Opacity = 0.75f
                };
                
                context.AddDataSet(dataSet1);

                var task = new Task(delegate
                {
                    do
                    {
                        points1 = new WavesPoint[num1];
                
                        for (var i = 0; i < num1; i++)
                        {
                            points1[i].X = i / (float) num1;
                            points1[i].Y = (float) random1.NextDouble() - 0.5f;
                        }
                    
                        context.UpdateDataSet(0, points1);
                        
                        Thread.Sleep(64);
                        
                    } while (true);
                });
                task.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

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