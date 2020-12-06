using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Drawing.Charting.Base.Interfaces;
using Waves.UI.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Drawing.Presentation.Interfaces;
using Waves.UI.Modality.Base;
using Waves.UI.Modality.Extensions;
using Waves.UI.Modality.Presentation;
using Waves.UI.Showcase.Common.Presentation.ViewModel.ModalWindow;

namespace Waves.UI.Showcase.Common.Presentation.ModalWindow
{
    /// <summary>
    /// Presenter for edit data set modal window.
    /// </summary>
    public class EditChartModalWindowPresenter : ModalWindowPresenter
    {
        /// <inheritdoc />
        public EditChartModalWindowPresenter(IWavesCore core, IDrawingElementPresenter presenter) : base(core)
        {
            Presenter = presenter;
        }

        /// <summary>
        /// Gets data set.
        /// </summary>
        public IDrawingElementPresenter Presenter { get; private set; }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Edit Data Set Modal Window Presenter";

        /// <inheritdoc />
        public override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title { get; } = "Editing chart";

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeView();
            InitializeActions();

            SetDataContext(new EditChartPresenterViewModel(Core, (IChartPresenterViewModel)Presenter.DataContext));

            base.Initialize();
        }

        /// <summary>
        ///     Initializes view.
        /// </summary>
        private void InitializeView()
        {
            MaxWidth = 640;
            MaxHeight = 480;
        }

        /// <summary>
        ///     Initializes actions.
        /// </summary>
        protected void InitializeActions()
        {
            var core = Core as Waves.UI.Core;
            if (core == null) return;

            this.AddAction(ModalWindowAction.Close(delegate { core.HideModalityWindow(this); }));
        }
    }
}