using System;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Checkbox tav view model.
    /// </summary>
    public class CheckBoxesTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public CheckBoxesTabViewModel(Core core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Checkboxes Tab View Model";
    }
}