using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     ComboBoxes tab presentation.
    /// </summary>
    public class ComboBoxesTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public ComboBoxesTabPresentation(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Comboboxes";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M2 6C0.895 6 0 6.895 0 8L0 16C0 17.105 0.895 18 2 18L14 18L14 6L2 6 z M 16 6L16 18L22 18C23.105 18 24 17.105 24 16L24 8C24 6.895 23.105 6 22 6L16 6 z M 17.5 11L22.5 11L20 13.5L17.5 11 z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -4, 0, 0};

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new ComboBoxesTabViewModel(Core);

            base.Initialize();
        }
    }
}