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
    public abstract class ShowPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of show property presentation.
        /// </summary>
        public ShowPropertyModalWindowPresentation(IProperty property)
        {
            Property = property;

            InitializeView();
            InitializeActions();
        }

        /// <inheritdoc />
        public abstract override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title { get; } = "Show property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <summary>
        ///     Gets property.
        /// </summary>
        public IProperty Property { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
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
        protected abstract void InitializeActions();
    }
}