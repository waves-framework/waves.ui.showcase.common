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
    public class MainTabPresentationController : PresentationController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core"></param>
        public MainTabPresentationController(Core core)
        {
            Core = core;
        }

        /// <summary>
        /// Gets or sets core.
        /// </summary>
        public Core Core { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
            try
            {
                RegisterPresentation(new TextTabPresentation(Core));
                RegisterPresentation(new ButtonsTabPresentation(Core));
                RegisterPresentation(new ComboBoxesTabPresentation(Core));
                RegisterPresentation(new CheckBoxesTabPresentation(Core));
                RegisterPresentation(new RadioButtonsTabPresentation(Core));
                RegisterPresentation(new TextBoxesTabPresentation(Core));
                RegisterPresentation(new ListBoxesTabPresentation(Core));
                RegisterPresentation(new ProgressBarsTabPresentation(Core));
                RegisterPresentation(new MenusTabPresentation(Core));
                RegisterPresentation(new ChartingTabPresentation(Core));
                RegisterPresentation(new ConfigurationTabPresentation(Core));
                RegisterPresentation(new CoreTabPresentation(Core));
                RegisterPresentation(new ThemeTabPresentation(Core));
                RegisterPresentation(new AboutTabPresentation(Core));

                OnMessageReceived(new Message("Initialization", "Main tab controller initialized.", "Main tab controller", MessageType.Success));

                if (Presentations.Count > 0)
                    SelectedPresentation = Presentations.First();
            }
            catch (Exception e)
            {
                OnMessageReceived(new Message("Initialization", "Error initialization main tab controller:\r\n" + e, "Main tab controller", MessageType.Error));
            }
        }
    }
}