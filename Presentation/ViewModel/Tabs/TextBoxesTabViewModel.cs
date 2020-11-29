using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    ///     TextBoxes tab view model.
    /// </summary>
    public class TextBoxesTabViewModel : ShowcaseTabViewModel
    {
        private ITextGeneratorService _textGeneratorService;


        /// <inheritdoc />
        public TextBoxesTabViewModel(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "TextBoxes Tab View Model";

        /// <summary>
        ///     Gets or sets text1.
        /// </summary>
        public string Text1 { get; set; }

        /// <summary>
        ///     Gets or sets text1.
        /// </summary>
        public string Text2 { get; set; }

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
            Text1 = _textGeneratorService.GenerateText();
            Text2 = _textGeneratorService.GenerateText();
        }
    }
}