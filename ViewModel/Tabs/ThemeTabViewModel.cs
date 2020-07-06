using Waves.Presentation.Base;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Theme tab view model.
    /// </summary>
    public class ThemeTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public ThemeTabViewModel(Core core) : base(core)
        {
        }

        /// <summary>
        ///     Gets theme service.
        /// </summary>
        public IThemeService ThemeService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            ThemeService = Core.GetService<IThemeService>();
        }
    }
}