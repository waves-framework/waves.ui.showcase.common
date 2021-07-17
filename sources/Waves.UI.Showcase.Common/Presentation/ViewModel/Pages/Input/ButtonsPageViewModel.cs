using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Pages.Input
{
    /// <summary>
    /// Tab view model for buttons.
    /// </summary>
    [WavesViewModel(typeof(ButtonsPageViewModel))]
    public class ButtonsPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ButtonsPageViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public ButtonsPageViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "Button";

        /// <inheritdoc />
        public override string Description => "Examples of button controls, which reacts to the Click event.";

        /// <inheritdoc />
        public override string Icon => "icon_button";

#pragma warning disable SA1124 // Do not use regions
        #region 5bf5132dd4a4fe672c055605beb40ca6-Command

        /// <summary>
        /// Gets button notification text.
        /// </summary>
        [Reactive]
        public string ButtonNotificationText { get; set; }

        /// <summary>
        /// Gets button command.
        /// </summary>
        [Reactive]
        public ICommand ButtonExampleCommand { get; private set; }

        #endregion

        #region 8601ad18957d75839485305c28114207-Command

        /// <summary>
        /// Gets accent button notification text.
        /// </summary>
        [Reactive]
        public string AccentButtonNotificationText { get; set; }

        /// <summary>
        /// Gets accent button command.
        /// </summary>
        public ICommand AccentButtonExampleCommand { get; private set; }

        #endregion

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            await base.InitializeAsync();

            InitializeButtonCommand();
            InitializeAccentButtonCommand();

            await AddRelatedPage<ToggleButtonsPageViewModel>();

            IsInitialized = true;
        }

        #region 5bf5132dd4a4fe672c055605beb40ca6-Initialization

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeButtonCommand()
        {
            ButtonExampleCommand = ReactiveCommand.CreateFromTask(OnButtonExample);
        }

        /// <summary>
        /// Actions when command invoked.
        /// </summary>
        private Task OnButtonExample()
        {
            ButtonNotificationText = "Button clicked.";
            return Task.CompletedTask;
        }

        #endregion

        #region 8601ad18957d75839485305c28114207-Initialization

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeAccentButtonCommand()
        {
            AccentButtonExampleCommand = ReactiveCommand.CreateFromTask(OnAccentButtonExample);
        }

        /// <summary>
        /// Actions when command invoked.
        /// </summary>
        private Task OnAccentButtonExample()
        {
            AccentButtonNotificationText = "Accent button clicked.";
            return Task.CompletedTask;
        }

        #endregion
    }
}
