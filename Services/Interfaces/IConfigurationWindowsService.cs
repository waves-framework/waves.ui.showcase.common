using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.Presentation.Interfaces;

namespace Waves.UI.Showcase.Common.Services.Interfaces
{
    /// <summary>
    /// Interface for configuration windows service.
    /// </summary>
    public interface IConfigurationWindowsService : IWavesService
    {
        /// <summary>
        /// Gets "Add property" presentation view.
        /// </summary>
        /// <returns>"Add property" presentation view.</returns>
        IPresenterView GetAddPropertyPresentationView();

        /// <summary>
        /// Gets "Show property" presentation view.
        /// </summary>
        /// <returns>"Show property" presentation view.</returns>
        IPresenterView GetShowPropertyPresentationView();

        /// <summary>
        /// Gets "Edit property" presentation view.
        /// </summary>
        /// <returns>"Edit property" presentation view.</returns>
        IPresenterView GetEditPropertyPresentationView();
    }
}