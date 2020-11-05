using System;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Radio buttons view model.
    /// </summary>
    public class RadioButtonsViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public RadioButtonsViewModel(Core core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "RadioButtons Tab View Model";
    }
}