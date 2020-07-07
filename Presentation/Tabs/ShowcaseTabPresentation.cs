using System;
using Waves.Presentation.Interfaces;
using Waves.UI.Presentation.Tabs;
using Waves.UI.Showcase.Common.ViewModel.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Tabs
{
    /// <summary>
    /// Showcase tab presentation.
    /// </summary>
    public abstract class ShowcaseTabPresentation : TabPresentation
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowcaseTabPresentation"/>.
        /// </summary>
        /// <param name="core">UI Core.</param>
        protected ShowcaseTabPresentation(Core core)
        {
            if (Core == null)
                throw new ArgumentNullException(nameof(core));

            Core = core;
        }

        /// <summary>
        /// Instance of UI core.
        /// </summary>
        public Core Core { get; private set; }

        /// <inheritdoc />
        public abstract override string Name { get; }

        /// <inheritdoc />
        public abstract override string VectorIconPathData { get; }

        /// <inheritdoc />
        public abstract override double[] VectorIconThickness { get; }

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public abstract override IPresentationViewModel DataContext { get; }
    }
}