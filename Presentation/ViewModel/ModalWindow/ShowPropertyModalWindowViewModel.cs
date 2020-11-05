using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.ViewModel;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.ModalWindow
{
    /// <summary>
    ///     Show property modal window view model.
    /// </summary>
    public class ShowPropertyModalWindowViewModel : ModalWindowPresenterViewModel
    {
        /// <summary>
        ///     Creates new instance of <see cref="ShowPropertyModalWindowViewModel" />.
        /// </summary>
        public ShowPropertyModalWindowViewModel(IProperty property)
        {
            Property = property;
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        public override string Name { get; set; } = "Show Property Modal Window View Model";

        /// <summary>
        ///     Gets  property.
        /// </summary>
        public IProperty Property { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}