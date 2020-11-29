using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    /// Showcase tab presentation.
    /// </summary>
    public abstract class ShowcaseTabPresentation : TabPresenter
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowcaseTabPresentation"/>.
        /// </summary>
        /// <param name="core">UI Core.</param>
        protected ShowcaseTabPresentation(IWavesCore core) : base(core)
        {
        }

        /// <inheritdoc />
        public abstract override string Name { get; }

        /// <inheritdoc />
        public abstract override string VectorIconPathData { get; }

        /// <inheritdoc />
        public abstract override double[] VectorIconThickness { get; }
    }
}