using Waves.Presentation.Base;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     TextBoxes tab view model.
    /// </summary>
    public class TextBoxesTabViewModel : ShowcaseTabViewModel
    {
        private ITextGeneratorService _textGeneratorService;


        /// <inheritdoc />
        public TextBoxesTabViewModel(Core core) : base(core)
        {
        }

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
            _textGeneratorService = Core.GetService<ITextGeneratorService>();

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