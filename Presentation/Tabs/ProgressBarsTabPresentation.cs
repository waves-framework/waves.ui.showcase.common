﻿using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     Progress bars tab presentation.
    /// </summary>
    public class ProgressBarsTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public ProgressBarsTabPresentation(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Progress";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M3.2128906 6C2.0035871 6 1 7.0035871 1 8.2128906L1 15.787109C1 16.996413 2.0035871 18 3.2128906 18L20.787109 18C21.996413 18 23 16.998173 23 15.789062L23 8.2128906C23 7.0035871 21.998172 6 20.789062 6L3.2128906 6 z M 15 8L20.789062 8C20.917953 8 21 8.0821941 21 8.2128906L21 15.789062C21 15.917954 20.917806 16 20.787109 16L15 16L15 8 z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -2, 0, 0};

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new ProgressBarsTabViewModel(Core);

            base.Initialize();
        }
    }
}