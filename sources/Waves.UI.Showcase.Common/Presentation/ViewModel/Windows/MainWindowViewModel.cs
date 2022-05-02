using Microsoft.Extensions.Logging;
using Waves.UI.Base.Attributes;
using Waves.UI.Presentation;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Windows
{
    /// <summary>
    /// View model for showcase main window.
    /// </summary>
    [WavesViewModel(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : WavesViewModelBase
    {
        /// <summary>
        /// Creates new instance of <see cref="MainWindowViewModel"/>.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public MainWindowViewModel(ILogger<WavesViewModelBase> logger)
            : base(logger)
        {
        }
    }
}
