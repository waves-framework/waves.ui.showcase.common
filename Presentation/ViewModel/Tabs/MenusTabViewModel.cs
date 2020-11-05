using System;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Menus tab view model.
    /// </summary>
    public class MenusTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public MenusTabViewModel(Core core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Menus Tab View Model";
    }
}