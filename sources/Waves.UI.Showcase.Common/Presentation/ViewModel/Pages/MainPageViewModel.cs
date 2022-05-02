using Microsoft.Extensions.Logging;
using ReactiveUI.Fody.Helpers;
using Waves.Core;
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
        /// Creates new instance of <see cref="MainPageViewModel"/>.
        /// </summary>
        /// <param name="core">Core.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="logger">Logger.</param>
        public MainPageViewModel(
            WavesCore core,
            IWavesNavigationService navigationService,
            ILogger<PageViewModel> logger)
            : base(core, navigationService, logger)
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
