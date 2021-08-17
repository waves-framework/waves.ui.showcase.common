using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.Core.Plugins.Services.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages
{
    /// <summary>
    /// Main control view model.
    /// </summary>
    [WavesViewModel(typeof(MainPageViewModel))]
    public class MainPageViewModel : PageViewModel
    {
        private readonly IWavesCore _core;
        private readonly IWavesNavigationService _navigationService;
        private TabViewModel _selectedTab;
        private string _xamlDocumentPath;
        private string _viewDocumentPath;
        private string _viewModelDocumentPath;

        /// <summary>
        /// Creates new instance of <see cref="MainPageViewModel"/>.
        /// </summary>
        /// <param name="core">Core.</param>
        /// <param name="navigationService">Navigation service.</param>
        public MainPageViewModel(IWavesCore core, IWavesNavigationService navigationService)
        : base(core, navigationService)
        {
            _core = core;
            _navigationService = navigationService;

            PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Gets performance counter service.
        /// </summary>
        public IWavesPerformanceCounterService PerformanceCounterService { get; }

        /// <summary>
        /// Gets or sets XAML document path.
        /// </summary>
        public string XamlDocumentPath
        {
            get => _xamlDocumentPath;
            set => this.RaiseAndSetIfChanged(ref _xamlDocumentPath, value);
        }

        /// <summary>
        /// Gets or sets view document path.
        /// </summary>
        public string ViewDocumentPath
        {
            get => _viewDocumentPath;
            set => this.RaiseAndSetIfChanged(ref _viewDocumentPath, value);
        }

        /// <summary>
        /// Gets or sets view-model document path.
        /// </summary>
        public string ViewModelDocumentPath
        {
            get => _viewModelDocumentPath;
            set => this.RaiseAndSetIfChanged(ref _viewModelDocumentPath, value);
        }

        /// <summary>
        /// Gets or sets selected tab.
        /// </summary>
        public TabViewModel SelectedTab
        {
            get => _selectedTab;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedTab, value);
            }
        }

        /// <summary>
        /// Gets collection of tabs.
        /// </summary>
        [Reactive]
        public ObservableCollection<TabViewModel> Tabs { get; protected set; }

        /// <inheritdoc />
        public override string Title { get; } = "Main page";

        /// <inheritdoc />
        public override string Description { get; } = "Main page";

        /// <inheritdoc />
        public override string Icon { get; } = string.Empty;

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            Tabs = new ObservableCollection<TabViewModel>();

            await InitializeTabs();

            IsInitialized = true;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            foreach (var tab in Tabs)
            {
                tab.Dispose();
            }

            // TODO: your code for release unmanaged resources.
        }

        /// <summary>
        /// Initializes application tabs.
        /// </summary>
        private async Task InitializeTabs()
        {
            await AddTab<InputTabViewModel>();
            await AddTab<TextTabViewModel>();
            await AddTab<TreeViewsTabViewModel>();
            await AddTab<NavigationTabViewModel>();
            await AddTab<ImagingTabViewModel>();

            if (Tabs.Count > 0)
            {
                SelectedTab = Tabs[0];
            }
        }

        /// <summary>
        /// Adds tab to collection by current type.
        /// </summary>
        /// <typeparam name="T">Type of tab view model.</typeparam>
        private async Task AddTab<T>()
            where T : TabViewModel
        {
            var viewModel = await _core.GetInstanceAsync<T>();
            await viewModel.InitializeAsync();
            Tabs.Add(viewModel);
        }

        private void OnPropertyChanged(
            object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(XamlDocumentPath)))
            {
            }
        }
    }
}
