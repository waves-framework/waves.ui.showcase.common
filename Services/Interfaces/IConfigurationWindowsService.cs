using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.Showcase.Common.Services.Interfaces
{
    /// <summary>
    /// Interface for configuration windows service.
    /// </summary>
    public interface IConfigurationWindowsService : IService
    {
        /// <summary>
        /// Gets "Add property" presentation view.
        /// </summary>
        /// <returns>"Add property" presentation view.</returns>
        IPresentationView GetAddPropertyPresentationView();

        /// <summary>
        /// Gets "Show property" presentation view.
        /// </summary>
        /// <returns>"Show property" presentation view.</returns>
        IPresentationView GetShowPropertyPresentationView();

        /// <summary>
        /// Gets "Edit property" presentation view.
        /// </summary>
        /// <returns>"Edit property" presentation view.</returns>
        IPresentationView GetEditPropertyPresentationView();
    }
}