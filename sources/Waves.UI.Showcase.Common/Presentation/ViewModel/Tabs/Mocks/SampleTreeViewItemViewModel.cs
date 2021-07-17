using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Plugins.Services.Interfaces;
using Waves.UI.Presentation;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Showcase.Common.Plugins.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs.Mocks
{
    /// <summary>
    /// Sample tree view item view model.
    /// </summary>
    [WavesViewModel(typeof(SampleTreeViewItemViewModel))]
    public class SampleTreeViewItemViewModel : WavesViewModelBase
    {
        private readonly IWavesContainerService _containerService;
        private readonly ITextGeneratorService _textGeneratorService;

        private bool _isOpened;
        private bool _childrenLoaded;

        /// <summary>
        /// Creates new instance of <see cref="SampleTreeViewItemViewModel"/>.
        /// </summary>
        /// <param name="containerService">Instance of text container service.</param>
        /// <param name="textGeneratorService">Instance of text generator service.</param>
        public SampleTreeViewItemViewModel(
            IWavesContainerService containerService,
            ITextGeneratorService textGeneratorService)
        {
            _containerService = containerService;
            _textGeneratorService = textGeneratorService;
        }

        /// <summary>
        /// Gets or sets whether item is opened.
        /// </summary>
        public bool IsOpened
        {
            get => _isOpened;
            set
            {
                this.RaiseAndSetIfChanged(ref _isOpened, value);
                OnOpenStateChanged();
            }
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        [Reactive]
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether item is available.
        /// </summary>
        [Reactive]
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets whether item is available.
        /// </summary>
        [Reactive]
        public bool IsSelected { get; set; }

        /// <summary>
        /// Gets children.
        /// </summary>
        [Reactive]
        public ObservableCollection<SampleTreeViewItemViewModel> Children { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            Children = new ObservableCollection<SampleTreeViewItemViewModel>();

            IsAvailable = true;
            Name = _textGeneratorService.GenerateWord();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Loads children.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LoadChildren()
        {
            if (_childrenLoaded)
            {
                return;
            }

            var random = new Random();
            var count = random.Next(20);

            for (var i = 0; i < count; i++)
            {
                var viewModel = await _containerService.GetInstanceAsync<SampleTreeViewItemViewModel>();
                await viewModel.InitializeAsync();

                viewModel.IsAvailable = random.Next(2) == 1;

                Children.Add(viewModel);
            }

            _childrenLoaded = true;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            foreach (var child in Children)
            {
                child.Dispose();
            }

            Children.Clear();
        }

        /// <summary>
        /// Callback when open state changed.
        /// </summary>
        private async void OnOpenStateChanged()
        {
            if (!IsOpened)
            {
                return;
            }

            foreach (var child in Children)
            {
                await child.LoadChildren();
            }
        }
    }
}
