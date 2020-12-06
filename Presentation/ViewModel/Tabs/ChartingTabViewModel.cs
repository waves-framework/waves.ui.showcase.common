using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
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
using Waves.UI.Showcase.Common.Presentation.ModalWindow;
using Waves.UI.Showcase.Common.Services.Interfaces;
using Waves.UI.WPF.Commands;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : ShowcaseTabViewModel
    {
        private WavesColor _chartColor = WavesColor.Black;
        
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
        /// Gets charting window service.
        /// </summary>
        public IChartingWindowService ChartingWindowService { get; private set; }

        /// <summary>
        /// Gets edit data set modal window presenter.
        /// </summary>
        [Reactive]
        public EditChartModalWindowPresenter EditChartModalWindowPresenter { get; private set; }

        /// <summary>
        /// Gets or sets selected drawing element presenter.
        /// </summary>
        [Reactive]
        public IDrawingElementPresenter SelectedDrawingElementPresenter { get; set; }

        /// <summary>
        /// Gets drawing element presenters.
        /// </summary>
        [Reactive]
        public ObservableCollection<IDrawingElementPresenter> DrawingElementPresenters { get; set; } = new ObservableCollection<IDrawingElementPresenter>();

        /// <summary>
        /// Gets command for "Add chart".
        /// </summary>
        public ICommand AddChartCommand { get; private set; }

        /// <summary>
        /// Gets command for "Remove chart".
        /// </summary>
        public ICommand RemoveChartCommand { get; private set; }

        /// <summary>
        /// Gets command for open edit data set window.
        /// </summary>
        public ICommand OpenChartEditModalWindowCommand { get; private set; }

        ///// <summary>
        /////     Gets drawing element presentation.
        ///// </summary>
        //[Reactive]
        //public IDrawingElementPresenter DrawingElementPresenter { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                InitializeServices();
                SubscribeEvents();
                InitializeCommands();

                AddNewChart();

                //var context = DrawingElementPresenter.DataContext as IDataSetChartPresenterViewModel;
                //if (context == null) return;

                //context.Update();

                //var num1 = 2048;
                //var random1 = new Random();
                //var points1 = new WavesPoint[num1];

                //for (var i = 0; i < num1; i++)
                //{
                //    points1[i].X = i / (float) num1;
                //    points1[i].Y = (float) random1.NextDouble() - 0.5f;
                //}

                //_chartColor = ThemeService.SelectedTheme.AccentColorSet.GetColor(500);

                //var dataSet1 = new DataSet(points1)
                //{
                //    Color = _chartColor,
                //    Type = DataSetType.BarWithEnvelope, Opacity = 0.75f
                //};

                //context.AddDataSet(dataSet1);

                //var task = new Task(delegate
                //{
                //    do
                //    {
                //        points1 = new WavesPoint[num1];

                //        for (var i = 0; i < num1; i++)
                //        {
                //            points1[i].X = i / (float) num1;
                //            points1[i].Y = (float) random1.NextDouble() - 0.5f;
                //        }

                //        context.DataSets[0].Color = _chartColor;
                //        context.UpdateDataSet(0, points1);

                //        Thread.Sleep(64);

                //    } while (true);
                //});
                //task.Start();
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new WavesMessage(
                        "Chart Tab Initialization",
                        "Error occured while initialization chart tab.",
                        Name,
                        e,
                        false));
            }
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            AddChartCommand = new Command(OnAddChart);
            RemoveChartCommand = new Command(OnRemoveChart, o => SelectedDrawingElementPresenter != null);
            OpenChartEditModalWindowCommand = new Command(OnOpenChartEditModalWindow);
        }

        /// <summary>
        /// Actions when chart adding.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void OnAddChart(object obj)
        {
            AddNewChart();
        }

        /// <summary>
        /// Actions when chart removing.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void OnRemoveChart(object obj)
        {
            RemoveChart(SelectedDrawingElementPresenter);
        }

        /// <summary>
        /// Actions when open data set edit modal window.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void OnOpenChartEditModalWindow(object obj)
        {
            if (!(Core is WPF.Core core)) return;
            if (!(obj is IDrawingElementPresenter presenter)) return;

            EditChartModalWindowPresenter = new EditChartModalWindowPresenter(core, presenter);
            EditChartModalWindowPresenter.SetView(ChartingWindowService.GetEditChartWindow());
            EditChartModalWindowPresenter.Initialize();

            core.ShowModalityWindow(EditChartModalWindowPresenter);
        }

        /// <summary>
        /// Adds new chart.
        /// </summary>
        private void AddNewChart()
        {
            try
            {
                var presenter = new DatasetChartPresenter(
                    Core,
                    ChartingService.GetChartViewFactory());

                presenter.MessageReceived += OnMessageReceived;

                presenter.Initialize();

                AddDefaultDataSet(presenter);

                DrawingElementPresenters.Add(presenter);
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new WavesMessage(
                        "Adding chart",
                        "Error occured while adding new chart.",
                        Name,
                        e,
                        false));
            }
        }

        /// <summary>
        /// Adds default data set.
        /// </summary>
        private void AddDefaultDataSet(IDrawingElementPresenter presenter)
        {
            if (!(presenter.DataContext is IDataSetChartPresenterViewModel context)) return;

            context.Update();

            var num = 2048;
            var random = new Random();
            var points = new WavesPoint[num];

            for (var i = 0; i < num; i++)
            {
                var x = i / (float)num;
                points[i].X = x;
                //points[i].Y = Convert.ToSingle(Math.Abs(Math.Sin(Math.Pow(x,x))/Math.Pow(2, (Math.Pow(x,x) - Math.PI /2 + random.NextDouble()) / 2.0d))) / 2.0f;
                points[i].Y = Convert.ToSingle(0.5 * Math.Sin(20*x));
            }

            _chartColor = ThemeService.SelectedTheme.AccentColorSet.GetColor(500);

            var dataSet1 = new DataSet(points)
            {
                Color = context.Color,
                Type = DataSetType.Line,
                Opacity = 0.75f
            };

            context.AddDataSet(dataSet1);
        }

        /// <summary>
        /// Removes chart.
        /// </summary>
        /// <param name="presenter">Chart presenter.</param>
        private void RemoveChart(IDrawingElementPresenter presenter)
        {
            try
            {
                presenter.MessageReceived -= OnMessageReceived;
                DrawingElementPresenters.Remove(presenter);

                SelectedDrawingElementPresenter = null;
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new WavesMessage(
                        "Removing chart",
                        "Error occured while removing chart.",
                        Name,
                        e,
                        false));
            }
        }

        /// <summary>
        /// Initializes services.
        /// </summary>
        private void InitializeServices()
        {
            DrawingService = Core.GetInstance<IDrawingService>();
            ThemeService = Core.GetInstance<IThemeService>();
            InputService = Core.GetInstance<IInputService>();
            ChartingService = Core.GetInstance<IChartingService>();
            ChartingWindowService = Core.GetInstance<IChartingWindowService>();
        }

        /// <summary>
        /// Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            ThemeService.ThemeChanged += OnThemeServiceThemeChanged;
            DrawingElementPresenters.CollectionChanged += OnDrawingElementPresentersCollectionChanged;
        }

        /// <summary>
        /// Actions when theme changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnThemeServiceThemeChanged(object sender, EventArgs e)
        {
            _chartColor = ThemeService.SelectedTheme.AccentColorSet.GetColor(500);
        }

        /// <summary>
        /// Actions when drawing element collection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDrawingElementPresentersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
    }
}