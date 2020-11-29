using System;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Core tab view model.
    /// </summary>
    public class CoreTabViewModel : ShowcaseTabViewModel
    {
        /// <inheritdoc />
        public CoreTabViewModel(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        [Reactive]
        public override string Name { get; set; } = "Core Tab View Model";
        
        /// <summary>
        /// Gets collection of messages.
        /// </summary>
        [Reactive]
        public ObservableCollection<IWavesMessageObject> Messages { get; protected set; } 
            = new ObservableCollection<IWavesMessageObject>();

        /// <inheritdoc />
        public override void Initialize()
        {
            Messages.Add(new WavesMessage("","","", WavesMessageType.Error));
            
            base.Initialize();
        }
    }
}