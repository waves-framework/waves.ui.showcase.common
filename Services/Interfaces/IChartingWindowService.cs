using Waves.Core.Base.Interfaces.Services;
using Waves.Presentation.Interfaces;

namespace Waves.UI.Showcase.Common.Services.Interfaces
{
    /// <summary>
    /// Interface for charting window service.
    /// </summary>
    public interface IChartingWindowService : IWavesService
    {
        /// <summary>
        /// Gets edit chart window.
        /// </summary>
        /// <returns>Chart window.</returns>
        IPresenterView GetEditChartWindow();
    }
}