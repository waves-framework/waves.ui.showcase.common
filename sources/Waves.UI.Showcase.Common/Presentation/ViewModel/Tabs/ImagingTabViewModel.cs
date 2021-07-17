using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.Core.Extensions;
using Waves.UI.Drawing;
using Waves.UI.Drawing.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Imaging tab view model.
    /// </summary>
    [WavesViewModel(typeof(ImagingTabViewModel))]
    public class ImagingTabViewModel : TabViewModel
    {
        private readonly int _delay = Convert.ToInt32(1000.0d / 10);
        private readonly List<IWavesDrawingObject> _pixels = new List<IWavesDrawingObject>();

        private int _height = 300;
        private int _width = 300;

        /// <summary>
        /// Creates new instance of <see cref="ImagingTabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        /// <param name="navigationService">Instance of navigation service.</param>
        public ImagingTabViewModel(IWavesCore core, IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "Imaging";

        /// <inheritdoc />
        public override string Icon { get; }

        /// <summary>
        /// Gets drawing objects.
        /// </summary>
        [Reactive]
        public ObservableCollection<IWavesDrawingObject> DrawingObjects { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return Task.CompletedTask;
            }

            DrawingObjects = new ObservableCollection<IWavesDrawingObject>();
            var source = new CancellationTokenSource();
            Randomise(source.Token).FireAndForget();

            IsInitialized = true;

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DrawingObjects.Clear();
                _pixels.Clear();
            }

            // TODO: your code for release unmanaged resources.
        }

        private async Task Randomise(CancellationToken token)
        {
            DrawingObjects.Clear();
            _pixels.Clear();

            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    var pixel = new WavesPixel()
                    {
                        Fill = Color.Black,
                        Point = new WavesPoint(i, j),
                    };

                    _pixels.Add(pixel);
                }
            }

            var random = new Random();
            do
            {
                DrawingObjects.Clear();

                foreach (var obj in _pixels)
                {
                    obj.Fill = Color.FromArgb(
                        255,
                        (byte)random.Next(255),
                        (byte)random.Next(255),
                        (byte)random.Next(255));
                }

                DrawingObjects.AddRange(_pixels);

                await Task.Delay(_delay, token);
            }
            while (!token.IsCancellationRequested);
        }
    }
}
