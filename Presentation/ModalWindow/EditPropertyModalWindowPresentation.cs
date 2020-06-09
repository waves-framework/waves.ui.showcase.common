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
    ///     Edit property presentation.
    /// </summary>
    public abstract class EditPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private readonly IConfiguration _configuration;

        private readonly IProperty _property;
        private IPresentationViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of add property modality window action.
        /// </summary>
        public EditPropertyModalWindowPresentation(IProperty property, IConfiguration configuration)
        {
            InitializeView();
            InitializeActions();

            _property = property;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public abstract override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title => "Edit property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new EditPropertyModalWindowViewModel(_property);

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