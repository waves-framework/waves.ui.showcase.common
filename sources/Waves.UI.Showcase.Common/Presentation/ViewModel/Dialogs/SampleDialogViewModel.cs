using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Presentation.Dialogs;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Dialogs
{
    /// <summary>
    /// Sample dialog view model.
    /// </summary>
    [WavesViewModel(typeof(SampleDialogViewModel))]
    public class SampleDialogViewModel : WavesDialogViewModelBase
    {
        /// <summary>
        /// Creates new instance of <see cref="SampleDialogViewModel"/>.
        /// </summary>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public SampleDialogViewModel(
            IWavesNavigationService navigationService)
            : base(navigationService)
        {
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: your code for release managed resources.
            }

            // TODO: your code for release unmanaged resources.
        }
    }
}
