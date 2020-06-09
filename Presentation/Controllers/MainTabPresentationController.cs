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
        /// <inheritdoc />
        public abstract override void Initialize();
    }
}