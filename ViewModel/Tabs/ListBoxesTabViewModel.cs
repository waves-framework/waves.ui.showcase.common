using System.Collections.ObjectModel;
using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Model;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Listboxes tab view model.
    /// </summary>
    public class ListBoxesTabViewModel : PresentationViewModel
    {
        private readonly ITextGeneratorService _textGeneratorService;

        /// <summary>
        ///     Creates new instance of <see cref="ListBoxesTabViewModel" />.
        /// </summary>
        /// <param name="textGeneratorService">Text generator service.</param>
        public ListBoxesTabViewModel(ITextGeneratorService textGeneratorService)
        {
            _textGeneratorService = textGeneratorService;
        }

        /// <summary>
        ///     Gets or sets selected item.
        /// </summary>
        public Item SelectedItem { get; set; }

        /// <summary>
        ///     Gets items.
        /// </summary>
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        /// <inheritdoc />
        public override void Initialize()
        {
            GenerateData();
        }

        /// <summary>
        ///     Generates data.
        /// </summary>
        private void GenerateData()
        {
            Items.Clear();

            for (var i = 0; i < 12; i++)
                Items.Add(new Item(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText()));
        }
    }
}