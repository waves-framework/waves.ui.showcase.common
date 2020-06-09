using System.Collections.ObjectModel;
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
    ///     Add property modality window presentation.
    /// </summary>
    public abstract class AddPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private readonly IConfiguration _configuration;
        private IPresentationViewModel _dataContext;

        private readonly ObservableCollection<IProperty> _properties;

        /// <summary>
        ///     Creates new instance of add property modality window action.
        /// </summary>
        public AddPropertyModalWindowPresentation(ObservableCollection<IProperty> properties,
            IConfiguration configuration)
        {
            InitializeView();
            InitializeActions();

            _properties = properties;
            _configuration = configuration;
        }

        /// <summary>
        ///     Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <inheritdoc />
        public abstract override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title => "Add property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new AddPropertyModalWindowViewModel();

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