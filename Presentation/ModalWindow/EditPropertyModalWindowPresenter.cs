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
    ///     Edit property presentation.
    /// </summary>
    public class EditPropertyModalWindowPresenter : ModalWindowPresenter
    {
        private readonly IWavesConfiguration _configuration;

        private readonly IWavesProperty _property;
        private IPresenterViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of add property modality window action.
        /// </summary>
        public EditPropertyModalWindowPresenter(
            IWavesCore core, 
            IWavesProperty property, 
            IWavesConfiguration configuration) 
            : base(core)
        {
            _property = property;
            _configuration = configuration;
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Edit Property Modal Window Presenter";

        /// <inheritdoc />
        public override IVectorImage Icon { get; }

        /// <inheritdoc />
        public override string Title => "Edit property";

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new EditPropertyModalWindowViewModel(Core,_property);

            InitializeView();
            InitializeActions();

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
            this.AddAction(ModalWindowAction.Save(delegate
            {
                var context = _dataContext as EditPropertyModalWindowViewModel;
                if (context == null) return;

                var property = context.GetResultProperty();

                _property.SetValue(property.GetValue());

                core.HideModalityWindow(this);
            }));
        }
    }
}