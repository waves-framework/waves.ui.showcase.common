using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces.Services;
using Waves.Presentation.Base;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Showcase tab view model.
    /// </summary>
    public abstract class ShowcaseTabViewModel : PresenterViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowcaseTabViewModel"/>.
        /// </summary>
        /// <param name="core">UI Core.</param>
        protected ShowcaseTabViewModel(Core core)
        {
            Core = core ?? throw new ArgumentNullException(nameof(core));
        }

        /// <summary>
        /// Instance of UI core.
        /// </summary>
        [Reactive]
        public Core Core { get; private set; }
        
        /// <summary>
        ///     Gets logging service.
        /// </summary>
        [Reactive]
        public ILoggingService LoggingService { get; private set; }

        /// <summary>
        /// Initializes view model.
        /// </summary>
        public override void Initialize()
        {
            InitializeServices();
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <summary>
        /// Initializes services.
        /// </summary>
        private void InitializeServices()
        {
            LoggingService = Core.GetInstance<ILoggingService>();
        }
    }
}