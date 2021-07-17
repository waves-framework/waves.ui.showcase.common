using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input
{
    /// <summary>
    /// ComboBoxes page view model.
    /// </summary>
    [WavesViewModel(typeof(ComboBoxesPageViewModel))]
    public class ComboBoxesPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ComboBoxesPageViewModel"/>.
        /// </summary>
        /// <param name="core">Core.</param>
        /// <param name="navigationService">Navigation service.</param>
        public ComboBoxesPageViewModel(IWavesCore core, IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "ComboBox";

        /// <inheritdoc />
        public override string Description => "A drop-down list of items a user can select from.";

        /// <inheritdoc />
        public override string Icon => "icon_combobox";

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (IsInitialized)
            {
                return;
            }

            await AddRelatedPage<TextBoxesPageViewModel>();

            IsInitialized = true;
        }
    }
}
