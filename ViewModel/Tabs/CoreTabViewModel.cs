using Waves.Core.Services.Interfaces;
using Waves.Presentation.Base;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Core tab view model.
    /// </summary>
    public class CoreTabViewModel : PresentationViewModel
    {
        /// <summary>
        ///     Creates new instance of <see cref="CoreTabViewModel" />.
        /// </summary>
        /// <param name="loggingService">Logging service.</param>
        public CoreTabViewModel(ILoggingService loggingService)
        {
            LoggingService = loggingService;
        }

        /// <summary>
        ///     Gets logging service.
        /// </summary>
        public ILoggingService LoggingService { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}