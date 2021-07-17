using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs.Mocks
{
    /// <summary>
    /// Sample page view model.
    /// </summary>
    [WavesViewModel(typeof(SamplePageViewModel))]
    public class SamplePageViewModel : WavesViewModelBase
    {
        private readonly IWavesNavigationService _navigationService;

        /// <summary>
        /// Creates new instance of <see cref="SamplePageViewModel"/>.
        /// </summary>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public SamplePageViewModel(
            IWavesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Gets command to go to page #2.
        /// </summary>
        public ICommand GoBackCommand { get; private set; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            GoBackCommand = ReactiveCommand.CreateFromTask<object>(OnGoBack);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Actions when going to page #2.
        /// </summary>
        /// <param name="obj">Parameter.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task OnGoBack(object obj)
        {
            return _navigationService.GoBackAsync(this);
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
    }
}
