using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
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
        protected ShowcaseTabViewModel(IWavesCore core) : base(core)
        {
        }

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
            try
            {
                InitializeServices();

                IsInitialized = true;
                
                var message = new WavesMessage(
                    "View model initialization",
                    $"Showcase tab view model {Name} ({Id}) was initialized.",
                    Name,
                    WavesMessageType.Information);

                OnMessageReceived(this, message);
                
                IsInitialized = true;
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    "View model initialization",
                    $"Error occured while initialization {Name} ({Id})",
                    Name,
                    e,
                    false);

                OnMessageReceived(this, message);
            }
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