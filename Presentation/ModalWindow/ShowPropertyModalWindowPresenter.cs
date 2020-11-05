using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Modality.Base;
using Waves.UI.Modality.Extensions;
using Waves.UI.Modality.Presentation;
using Waves.UI.Showcase.Common.Presentation.ViewModel.ModalWindow;

namespace Waves.UI.Showcase.Common.Presentation.ModalWindow
{
    /// <summary>
    ///     Show property presentation.
    /// </summary>
    public class ShowPropertyModalWindowPresenter : ModalWindowPresenter
    {
        private IPresenterViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of show property presentation.
        /// </summary>
        public ShowPropertyModalWindowPresenter(Core core, IProperty property) : base(core)
        {
            Property = property;
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Show Property Modal Window Presenter";

        /// <inheritdoc />
        public override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title { get; } = "Show property";

        /// <summary>
        ///     Gets property.
        /// </summary>
        public IProperty Property { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeView();
            InitializeActions();

            _dataContext = new ShowPropertyModalWindowViewModel(Property);

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
            this.AddAction(ModalWindowAction.Close(delegate { Core.HideModalityWindow(this); }));
        }
    }
}