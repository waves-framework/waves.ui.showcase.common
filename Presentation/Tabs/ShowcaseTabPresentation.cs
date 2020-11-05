using System;
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
        protected ShowcaseTabPresentation(Core core)
        {
            Core = core ?? throw new ArgumentNullException(nameof(core));
        }

        /// <summary>
        /// Instance of UI core.
        /// </summary>
        protected Core Core { get; private set; }

        /// <inheritdoc />
        public abstract override string Name { get; }

        /// <inheritdoc />
        public abstract override string VectorIconPathData { get; }

        /// <inheritdoc />
        public abstract override double[] VectorIconThickness { get; }
    }
}