using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs.Mocks;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Tree view tab view model.
    /// </summary>
    [WavesViewModel(typeof(TreeViewsTabViewModel))]
    public class TreeViewsTabViewModel : TabViewModel
    {
        private ObservableCollection<SampleTreeViewItemViewModel> _items;

        /// <summary>
        /// Creates new instance of <see cref="TreeViewsTabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public TreeViewsTabViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "TreeViews";

        /// <inheritdoc />
        public override string Icon { get; }

        /// <summary>
        /// Selected item.
        /// </summary>
        [Reactive]
        public SampleTreeViewItemViewModel SelectedItem { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        public ObservableCollection<SampleTreeViewItemViewModel> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        /// <summary>
        /// Gets refresh command.
        /// </summary>
        public ICommand RefreshCommand { get; private set; }

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            await RefreshData();

            RefreshCommand = ReactiveCommand.CreateFromTask(RefreshData);

            IsInitialized = true;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: your code for release managed resources.
            }

            // TODO: your code for release unmanaged resources.
        }

        /// <summary>
        /// Refreshes data.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task RefreshData()
        {
            Items = new ObservableCollection<SampleTreeViewItemViewModel>();

            var random = new Random();
            var count = random.Next(20);

            for (var i = 0; i < count; i++)
            {
                var viewModel = await Core.GetInstanceAsync<SampleTreeViewItemViewModel>();
                await viewModel.InitializeAsync();
                await viewModel.LoadChildren();

                viewModel.IsAvailable = random.Next(2) == 1;

                Items.Add(viewModel);
            }

            if (Items.Count > 0)
            {
                SelectedItem = Items[0];
            }
        }
    }
}
