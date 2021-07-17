using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation.Attributes;
using Waves.UI.Presentation.Dialogs;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Dialogs
{
    /// <summary>
    /// Sample dialog view model.
    /// </summary>
    [WavesViewModel(typeof(SampleDialogWithResultViewModel))]
    public class SampleDialogWithResultViewModel : WavesDialogViewModelBase<string>
    {
        private string _resultText;

        /// <summary>
        /// Creates new instance of <see cref="SampleDialogWithResultViewModel"/>.
        /// </summary>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        public SampleDialogWithResultViewModel(
            IWavesNavigationService navigationService)
            : base(navigationService)
        {
        }

        /// <summary>
        /// Gets or sets result text.
        /// </summary>
        [Reactive]
        public string ResultText
        {
            get => _resultText;
            set
            {
                this.RaiseAndSetIfChanged(ref _resultText, value);
                Result = ResultText;
            }
        }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            ResultText = "Sample text";
            return base.InitializeAsync();
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
