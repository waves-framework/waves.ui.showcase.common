using System;
using System.Collections.ObjectModel;
using Waves.Core.Base.Interfaces;
using Waves.UI.Showcase.Common.Model;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     Listboxes tab view model.
    /// </summary>
    public class ListBoxesTabViewModel : ShowcaseTabViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <inheritdoc />
        public ListBoxesTabViewModel(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "ListBoxes Tab View Model";

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
            base.Initialize();
            
            _textGeneratorService = Core.GetInstance<ITextGeneratorService>();

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