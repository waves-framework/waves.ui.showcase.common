using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     Buttons tab presentation.
    /// </summary>
    public class ButtonsTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public ButtonsTabPresentation(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Buttons";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M22,7H2C0.895,7,0,7.895,0,9v6c0,1.105,0.895,2,2,2h20c1.105,0,2-0.895,2-2V9C24,7.895,23.105,7,22,7z M13,13h-2v-2h2V13z M17,13h-2v-2h2V13z M9,13H7v-2h2V13z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -4, 0, 0};

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new ButtonsTabViewModel(Core);

            base.Initialize();
        }
    }
}