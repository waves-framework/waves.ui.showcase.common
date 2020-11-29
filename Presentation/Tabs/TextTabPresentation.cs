﻿using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    ///     Text tab presentation.
    /// </summary>
    public class TextTabPresentation : ShowcaseTabPresentation
    {
        /// <inheritdoc />
        public TextTabPresentation(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Text styles";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M4 3L4 7L6 7L6 5L11 5L11 19L9 19L9 21L15 21L15 19L13 19L13 5L18 5L18 7L20 7L20 3L4 3 z";

        /// <inheritdoc />
        public override double[] VectorIconThickness { get; } = new double[4] {0, -2, 0, 0};

        /// <inheritdoc />
        public override void Initialize()
        {
            DataContext = new TextTabViewModel(Core);

            base.Initialize();
        }
    }
}