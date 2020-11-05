using System;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Buttons tab view model.
    /// </summary>
    public class ButtonsTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public ButtonsTabViewModel(Core core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Buttons Tab View Model";
    }
}