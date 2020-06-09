﻿using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     About tab presentation.
    /// </summary>
    public abstract class AboutTabPresentation : TabPresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "About";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12,0.143c0,0-8,8.486-8,13.857c0,4.457,3.543,8,8,8s8-3.543,8-8C20,8.629,12,0.143,12,0.143z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4];

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new AboutTabViewModel();
    }
}