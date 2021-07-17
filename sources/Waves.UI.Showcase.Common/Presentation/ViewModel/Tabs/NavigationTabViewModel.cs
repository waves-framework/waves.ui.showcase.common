using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Presentation.Dialogs.Enums;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Dialogs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs.Mocks;
using Waves.UI.Showcase.Common.Presentation.ViewModel.UserControl;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// System tab view model.
    /// </summary>
    [WavesViewModel(typeof(NavigationTabViewModel))]
    public class NavigationTabViewModel : TabViewModel
    {
        private readonly IWavesDialogService _dialogService;

        private string _resultText;

        /// <summary>
        /// Creates new instance of <see cref="NavigationTabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        /// <param name="dialogService">Instance of <see cref="IWavesDialogService"/>.</param>
        public NavigationTabViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService,
            IWavesDialogService dialogService)
            : base(core, navigationService)
        {
            _dialogService = dialogService;
        }

        /// <inheritdoc />
        public override string Title => "Navigation";

        /// <inheritdoc />
        public override string Icon => "icon_navigation";

        /// <summary>
        /// Gets or sets result text.
        /// </summary>
        public string ResultText
        {
            get => _resultText;
            set => this.RaiseAndSetIfChanged(ref _resultText, value);
        }

        /// <summary>
        /// Gets command to go to sample page.
        /// </summary>
        public ICommand GoToSamplePageCommand { get; private set; }

        /// <summary>
        /// Gets command to show sample dialog.
        /// </summary>
        public ICommand ShowSampleDialogCommand { get; private set; }

        /// <summary>
        /// Gets command to show sample dialog which returns result.
        /// </summary>
        public ICommand ShowSampleDialogWithResultCommand { get; private set; }

        /// <summary>
        /// Gets command to show sample message dialog with text.
        /// </summary>
        public ICommand ShowTextMessageDialogCommand { get; private set; }

        /// <summary>
        /// Gets command for going back for user controls.
        /// </summary>
        public ICommand UserControlGoBackCommand { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return Task.CompletedTask;
            }

            GoToSamplePageCommand = ReactiveCommand.CreateFromTask<object>(OnGoToSamplePage);
            ShowSampleDialogCommand = ReactiveCommand.CreateFromTask<object>(OnShowSampleDialog);
            UserControlGoBackCommand = ReactiveCommand.CreateFromTask(OnUserControlGoBack);

            // TODO: we have a bug with calling dialog with result with Task command.
            // TODO: need to research this thing.
            ShowSampleDialogWithResultCommand = ReactiveCommand.Create(OnShowSampleDialogWithResult);
            ShowTextMessageDialogCommand = ReactiveCommand.Create(OnShowTextMessageDialog);

            IsInitialized = true;

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override async Task ViewAppeared()
        {
            await NavigationService.NavigateAsync<FirstSampleUserControlViewModel>();
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
        /// Actions when going to sample page.
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private async Task OnGoToSamplePage(object obj)
        {
            await NavigationService.NavigateAsync<SamplePageViewModel>();
        }

        /// <summary>
        /// Actions when showing sample dialog.
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private async Task OnShowSampleDialog(object obj)
        {
            await NavigationService.NavigateAsync<SampleDialogViewModel>();
        }

        /// <summary>
        /// Shows dialog and gets result from it.
        /// </summary>
        private async void OnShowSampleDialogWithResult()
        {
            var result = await NavigationService.NavigateAsync<SampleDialogWithResultViewModel, string>();

            if (!string.IsNullOrEmpty(result))
            {
                ResultText = result;
            }
        }

        /// <summary>
        /// Shows basic message dialog with text.
        /// </summary>
        private async void OnShowTextMessageDialog()
        {
            var result = await _dialogService.ShowDialogAsync("Hello world!", buttons: WavesMessageDialogButtons.AbortRetryIgnore);
        }

        /// <summary>
        /// Actions when go back with user control.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task OnUserControlGoBack()
        {
            await NavigationService.GoBackAsync("SampleRegion");
        }
    }
}
