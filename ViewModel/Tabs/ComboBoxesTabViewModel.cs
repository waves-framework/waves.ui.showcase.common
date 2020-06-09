using System.Collections.ObjectModel;
using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Comboboxes tab view model.
    /// </summary>
    public class ComboBoxesTabViewModel : PresentationViewModel
    {
        private readonly ITextGeneratorService _textGeneratorService;

        /// <summary>
        ///     Creates new instance of <see cref="ComboBoxesTabViewModel" />.
        /// </summary>
        /// <param name="textGeneratorService">Text generator service.</param>
        public ComboBoxesTabViewModel(ITextGeneratorService textGeneratorService)
        {
            _textGeneratorService = textGeneratorService;
        }

        /// <summary>
        ///     Gets words collection.
        /// </summary>
        public ObservableCollection<string> Words { get; set; } = new ObservableCollection<string>();

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
            for (var i = 0; i < 10; i++) Words.Add(_textGeneratorService.GenerateWord());
        }
    }
}