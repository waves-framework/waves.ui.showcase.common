using System;
using Waves.Presentation.Base;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    /// Showcase tab view model.
    /// </summary>
    public abstract class ShowcaseTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowcaseTabViewModel"/>.
        /// </summary>
        /// <param name="core">UI Core.</param>
        protected ShowcaseTabViewModel(Core core)
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
        public abstract override void Initialize();
    }
}