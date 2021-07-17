using System.Threading.Tasks;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input
{
    /// <summary>
    /// Tab view model for buttons.
    /// </summary>
    [WavesViewModel(typeof(TextBoxesPageViewModel))]
    public class TextBoxesPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="TextBoxesPageViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public TextBoxesPageViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "TextBox";

        /// <inheritdoc />
        public override string Description => "Examples of control that can be used to display or edit unformatted text.";

        /// <inheritdoc />
        public override string Icon => "icon_textbox";

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (IsInitialized)
            {
                return;
            }

            await AddRelatedPage<ComboBoxesPageViewModel>();

            IsInitialized = true;
        }
    }
}
