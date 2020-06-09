using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     CheckBox tab presentation.
    /// </summary>
    public abstract class CheckBoxesTabPresentation : TabPresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Checkboxes";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M19,3H5C3.895,3,3,3.895,3,5v14c0,1.105,0.895,2,2,2h14c1.105,0,2-0.895,2-2V5C21,3.895,20.105,3,19,3z M10,17.414 l-4.707-4.707l1.414-1.414L10,14.586l7.293-7.293l1.414,1.414L10,17.414z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4];

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new CheckBoxesTabViewModel();
    }
}