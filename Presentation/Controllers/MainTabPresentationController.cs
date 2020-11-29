using System;
using System.Linq;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Presentation.Tabs;

namespace Waves.UI.Showcase.Common.Presentation.Controllers
{
    /// <summary>
    ///     Main Tabs presentation controller.
    /// </summary>
    public abstract class MainTabPresentationController : PresenterController
    {
        /// <summary>
        /// Creates new instance of <see cref="MainTabPresentationController"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        protected MainTabPresentationController(IWavesCore core) : base(core)
        {
        }

        /// <inheritdoc />
        public abstract override void Initialize();
    }
}