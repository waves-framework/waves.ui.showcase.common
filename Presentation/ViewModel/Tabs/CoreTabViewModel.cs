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
        public CoreTabViewModel(Core core) : base(core)
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
        public ObservableCollection<IMessageObject> Messages { get; protected set; } 
            = new ObservableCollection<IMessageObject>();

        /// <inheritdoc />
        public override void Initialize()
        {
            Messages.Add(new Message("","","", MessageType.Error));
            
            base.Initialize();
        }
    }
}