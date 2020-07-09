using System;
using System.Linq;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Presentation.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Controllers
{
    /// <summary>
    ///     Main Tabs presentation controller.
    /// </summary>
    public abstract class MainTabPresentationController : PresentationController
    {
        /// <summary>
        /// Creates new instance of <see cref="MainTabPresentationController"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        protected MainTabPresentationController(Core core)
        {
            Core = core;
        }

        /// <summary>
        /// Gets or sets core.
        /// </summary>
        public Core Core { get; }

        /// <inheritdoc />
        public abstract override void Initialize();
    }
}