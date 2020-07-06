using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     Radio buttons tab presentation.
    /// </summary>
    public class RadioButtonsTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public RadioButtonsTabPresentation(Core core) : base(core)
        {
        }

        /// <inheritdoc />
        public override string Name { get; } = "RadioButtons";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12 2C6.4889971 2 2 6.4889971 2 12C2 17.511003 6.4889971 22 12 22C17.511003 22 22 17.511003 22 12C22 6.4889971 17.511003 2 12 2 z M 12 4C16.430123 4 20 7.5698774 20 12C20 16.430123 16.430123 20 12 20C7.5698774 20 4 16.430123 4 12C4 7.5698774 7.5698774 4 12 4 z M 12 6 A 6 6 0 0 0 6 12 A 6 6 0 0 0 12 18 A 6 6 0 0 0 18 12 A 6 6 0 0 0 12 6 z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4];

        /// <inheritdoc />
        public override IPresentationView View { get; protected set; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new RadioButtonsViewModel(Core);

            base.Initialize();
        }
    }
}