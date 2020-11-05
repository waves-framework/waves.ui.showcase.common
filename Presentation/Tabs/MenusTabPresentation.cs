using System;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    /// Menus tab presentation.
    /// </summary>
    public class MenusTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public MenusTabPresentation(Core core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Menus";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12 2C6.476563 2 2 6.476563 2 12C2 17.523438 6.476563 22 12 22C17.523438 22 22 17.523438 22 12C22 6.476563 17.523438 2 12 2 Z M 17 17L7 17L7 15L17 15 Z M 17 13L7 13L7 11L17 11 Z M 17 9L7 9L7 7L17 7Z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -2, 0, 0};

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new MenusTabViewModel(Core);

            base.Initialize();
        }
    }
}