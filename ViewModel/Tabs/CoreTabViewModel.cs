using Waves.Core.Services.Interfaces;
using Waves.Presentation.Base;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Core tab view model.
    /// </summary>
    public class CoreTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public CoreTabViewModel(Core core) : base(core)
        {
        }

        /// <summary>
        ///     Gets logging service.
        /// </summary>
        public ILoggingService LoggingService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            LoggingService = Core.GetService<ILoggingService>();
        }
    }
}