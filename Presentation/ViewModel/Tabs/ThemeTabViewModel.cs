using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Theme tab view model.
    /// </summary>
    public class ThemeTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public ThemeTabViewModel(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Theme Tab View Model";

        /// <summary>
        ///     Gets theme service.
        /// </summary>
        public IThemeService ThemeService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();
            
            ThemeService = Core.GetInstance<IThemeService>();
        }
    }
}