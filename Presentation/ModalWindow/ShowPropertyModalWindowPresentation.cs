using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Modality.Base;
using Waves.UI.Modality.Extensions;
using Waves.UI.Modality.Presentation;
using Waves.UI.Showcase.Common.ViewModel.ModalWindow;

namespace Waves.UI.Showcase.Common.Presentation.ModalWindow
{
    /// <summary>
    ///     Show property presentation.
    /// </summary>
    public class ShowPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of show property presentation.
        /// </summary>
        public ShowPropertyModalWindowPresentation(Core core, IProperty property) : base(core)
        {
            Property = property;
        }

        /// <inheritdoc />
        public override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title { get; } = "Show property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        public override IPresentationView View { get; protected set; }

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