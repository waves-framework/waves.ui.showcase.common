using System.Collections.ObjectModel;
using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Comboboxes tab view model.
    /// </summary>
    public class ComboBoxesTabViewModel : ShowcaseTabViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <inheritdoc />
        public ComboBoxesTabViewModel(Core core) : base(core)
        {
        }

        /// <summary>
        ///     Gets words collection.
        /// </summary>
        public ObservableCollection<string> Words { get; set; } = new ObservableCollection<string>();

        /// <inheritdoc />
        public override void Initialize()
        {
            _textGeneratorService = Core.GetService<ITextGeneratorService>();

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