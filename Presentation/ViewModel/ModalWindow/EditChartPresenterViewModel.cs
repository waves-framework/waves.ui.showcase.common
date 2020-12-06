using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.UI.Drawing.Charting.Base.Interfaces;
using Waves.UI.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Drawing.Presentation.Interfaces;
using Waves.UI.Modality.ViewModel;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.ModalWindow
{
    /// <summary>
    /// View model for data set editing.
    /// </summary>
    public class EditChartPresenterViewModel : ModalWindowPresenterViewModel
    {
        /// <inheritdoc />
        public EditChartPresenterViewModel(IWavesCore core, IChartPresenterViewModel viewModel) : base(core)
        {
            ViewModel = viewModel;
        }

        /// <summary>
        /// Gets data set;
        /// </summary>
        [Reactive]
        public IChartPresenterViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Edit Data Set Presenter View Model";

        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}