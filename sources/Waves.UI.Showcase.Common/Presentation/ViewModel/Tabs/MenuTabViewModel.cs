using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Menu tab view model.
    /// </summary>
    [WavesViewModel(typeof(MenuTabViewModel))]
    public class MenuTabViewModel : TabViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="MenuTabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public MenuTabViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "Menu";

        /// <inheritdoc />
        public override string Icon { get; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return Task.CompletedTask;
            }

            IsInitialized = true;

            return Task.CompletedTask;
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
