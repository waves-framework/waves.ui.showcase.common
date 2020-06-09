using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    public abstract class MenusTabPresentation : TabPresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Menus";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12 2C6.476563 2 2 6.476563 2 12C2 17.523438 6.476563 22 12 22C17.523438 22 22 17.523438 22 12C22 6.476563 17.523438 2 12 2 Z M 17 17L7 17L7 15L17 15 Z M 17 13L7 13L7 11L17 11 Z M 17 9L7 9L7 7L17 7Z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -2, 0, 0};

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new MenusTabViewModel();
    }
}