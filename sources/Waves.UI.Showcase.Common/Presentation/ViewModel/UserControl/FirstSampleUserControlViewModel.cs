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
    [WavesViewModel(typeof(FirstSampleUserControlViewModel))]
    public class FirstSampleUserControlViewModel : WavesViewModelBase
    {
        private readonly IWavesNavigationService _navigationService;

        /// <summary>
        /// Creates new instance of <see cref="FirstSampleUserControlViewModel"/>.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public FirstSampleUserControlViewModel(
            IWavesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Commands for going to second control.
        /// </summary>
        public ICommand GoToSecondUserControlCommand { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            GoToSecondUserControlCommand = ReactiveCommand.CreateFromTask(OnGoToSecondUserControl);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Goes to second user control.
        /// </summary>
        private async Task OnGoToSecondUserControl()
        {
            await _navigationService.NavigateAsync<SecondSampleUserControlViewModel>();
        }
    }
}
