using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input
{
    /// <summary>
    /// Tab view model for radiobuttons examples.
    /// </summary>
    [WavesViewModel(typeof(RadioButtonsPageViewModel))]
    public class RadioButtonsPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="RadioButtonsPageViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public RadioButtonsPageViewModel(IWavesCore core, IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "RadioButton";

        /// <inheritdoc />
        public override string Description =>
            "A graphical control element that allows the user to choose only one of a predefined set of mutually exclusive options.";

        /// <inheritdoc />
        public override string Icon => "icon_radiobutton";

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            await base.InitializeAsync();

            await AddRelatedPage<CheckBoxesPageViewModel>();

            IsInitialized = true;
        }
    }
}
