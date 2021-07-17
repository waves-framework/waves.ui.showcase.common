using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.UserControl
{
    /// <summary>
    /// First sample user control view model.
    /// </summary>
    [WavesViewModel(typeof(SecondSampleUserControlViewModel))]
    public class SecondSampleUserControlViewModel : WavesViewModelBase
    {
        private readonly IWavesNavigationService _navigationService;

        /// <summary>
        /// Creates new instance of <see cref="SecondSampleUserControlViewModel"/>.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public SecondSampleUserControlViewModel(
            IWavesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Commands for going to second control.
        /// </summary>
        public ICommand GoToFirstControlCommand { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            GoToFirstControlCommand = ReactiveCommand.CreateFromTask(OnGoToFirstUserControl);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Goes to second user control.
        /// </summary>
        private async Task OnGoToFirstUserControl()
        {
            await _navigationService.NavigateAsync<FirstSampleUserControlViewModel>();
        }
    }
}
