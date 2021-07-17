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
    [WavesViewModel(typeof(ToggleButtonsPageViewModel))]
    public class ToggleButtonsPageViewModel : PageViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ToggleButtonsPageViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public ToggleButtonsPageViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
            : base(core, navigationService)
        {
        }

        /// <inheritdoc />
        public override string Title => "Toggle button";

        /// <inheritdoc />
        public override string Description => "Examples of toggle button controls, which have two states like CheckBox.";

        /// <inheritdoc />
        public override string Icon => "icon_togglebutton";

#pragma warning disable SA1124 // Do not use regions
        #region c102e73e3eaee4f991f6ab430e282f50-Command

        /// <summary>
        /// Gets or sets whether is button checked.
        /// </summary>
        [Reactive]
        public bool IsButtonChecked { get; set; }

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

        /// <inheritdoc />
        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            await base.InitializeAsync();

            InitializeButtonCommand();

            await AddRelatedPage<ButtonsPageViewModel>();
            await AddRelatedPage<CheckBoxesPageViewModel>();

            IsInitialized = true;
        }

        #region c102e73e3eaee4f991f6ab430e282f50-Initialization

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
            ButtonNotificationText = IsButtonChecked ? "Button checked." : "Button unchecked.";

            return Task.CompletedTask;
        }

        #endregion
    }
}
