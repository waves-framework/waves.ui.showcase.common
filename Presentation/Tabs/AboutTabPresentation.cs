using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     About tab presentation.
    /// </summary>
    public class AboutTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public AboutTabPresentation(Core core) : base(core)
        {
        }

        /// <inheritdoc />
        public override string Name { get; } = "About";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12,0.143c0,0-8,8.486-8,13.857c0,4.457,3.543,8,8,8s8-3.543,8-8C20,8.629,12,0.143,12,0.143z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4];

        /// <inheritdoc />
        public override IPresentationView View { get; protected set; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            //DataContext = new AboutTabViewModel(Core);

            //base.Initialize();

            SetDataContext(new AboutTabViewModel(Core));
        }
    }
}