using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input
{
    /// <summary>
    /// Tab view model for radiobuttons examples.
    /// </summary>
    [WavesViewModel(typeof(CheckBoxesPageViewModel))]
    public class CheckBoxesPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="CheckBoxesPageViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public CheckBoxesPageViewModel(IWavesCore core, IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "CheckBox";

        /// <inheritdoc />
        public override string Description =>
            "A checkbox is a GUI widget that permits the user to make a binary choice, i.e. a choice between one of two possible mutually exclusive options.";

        /// <inheritdoc />
        public override string Icon => "icon_checkbox";

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            await base.InitializeAsync();

            await AddRelatedPage<ToggleButtonsPageViewModel>();
            await AddRelatedPage<RadioButtonsPageViewModel>();

            IsInitialized = true;
        }
    }
}
