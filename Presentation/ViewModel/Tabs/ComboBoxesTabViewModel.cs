using System;
using System.Collections.ObjectModel;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
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
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "ComboBoxes Tab View Model";

        /// <summary>
        ///     Gets words collection.
        /// </summary>
        public ObservableCollection<string> Words { get; set; } = new ObservableCollection<string>();

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();
            
            _textGeneratorService = Core.GetInstance<ITextGeneratorService>();

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