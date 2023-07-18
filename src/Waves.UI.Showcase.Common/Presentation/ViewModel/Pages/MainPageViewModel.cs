using Microsoft.Extensions.Logging;
using ReactiveUI.Fody.Helpers;
using Waves.Core;
using Waves.Core.Services.Interfaces;
using Waves.UI.Base.Attributes;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages
{
    /// <summary>
    /// Main control view model.
    /// </summary>
    [WavesViewModel(typeof(MainPageViewModel))]
    public class MainPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.s
        /// </summary>
        /// <param name="serviceProvider">Service provider.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="logger">Logger.</param>
        public MainPageViewModel(
            IWavesServiceProvider serviceProvider,
            IWavesNavigationService navigationService,
            ILogger<MainPageViewModel> logger)
            : base(serviceProvider, navigationService, logger)
        {
        }

        /// <inheritdoc />
        public override string Title { get; } = "Main page";

        /// <inheritdoc />
        public override string Description { get; } = "Main page";

        /// <inheritdoc />
        public override string Icon { get; } = string.Empty;
    }
}
