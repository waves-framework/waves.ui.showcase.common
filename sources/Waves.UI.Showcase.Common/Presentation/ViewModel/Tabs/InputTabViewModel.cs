using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Basic input controls tab view model.
    /// </summary>
    [WavesViewModel(typeof(InputTabViewModel))]
    public class InputTabViewModel : TabViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="InputTabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        /// <param name="navigationService">Instance of navigation service.</param>
        public InputTabViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "Input";

        /// <inheritdoc />
        public override string Icon => "icon_left_click";

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (IsInitialized)
            {
                return;
            }

            await AddPage<ButtonsPageViewModel>();

            IsInitialized = true;
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
