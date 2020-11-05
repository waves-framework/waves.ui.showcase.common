using System;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     About tab view model.
    /// </summary>
    public class AboutTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public AboutTabViewModel(Core core) : base(core)
        {
        }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "About Tab View Model";
    }
}