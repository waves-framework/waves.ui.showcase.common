using System;
using System.Collections.ObjectModel;
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
    ///     Add property modality window presentation.
    /// </summary>
    public class AddPropertyModalWindowPresenter : ModalWindowPresenter
    {
        private readonly IConfiguration _configuration;
        private IPresenterViewModel _dataContext;

        private readonly ObservableCollection<IProperty> _properties;

        /// <summary>
        ///     Creates new instance of add property modality window action.
        /// </summary>
        public AddPropertyModalWindowPresenter(Core core, ObservableCollection<IProperty> properties,
            IConfiguration configuration) : base(core)
        {
            _properties = properties;
            _configuration = configuration;
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Add property modal windows presenter";

        /// <summary>
        ///     Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <inheritdoc />
        public override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title => "Add property";

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeView();
            InitializeActions();

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
        protected void InitializeActions()
        {
            this.AddAction(ModalWindowAction.Close(delegate { Core.HideModalityWindow(this); }));

            this.AddAction(ModalWindowAction.Save(delegate
            {
                var context = _dataContext as AddPropertyModalWindowViewModel;
                if (context == null) return;

                var property = context.GetResultProperty();

                _configuration.AddProperty(property);

                _properties.Add(property);

                Core.HideModalityWindow(this);
            }));
        }
    }
}