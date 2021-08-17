using System.Threading.Tasks;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Waves.Core.Base;
using Waves.Core.Base.Attributes;
using Waves.UI.Showcase.Common.Plugins.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Plugins.Services
{
    /// <summary>
    ///     Text generator service.
    /// </summary>
    [WavesService("b2f9aaa2-ecba-42e7-9dbc-7bccaf733cc6", typeof(ITextGeneratorService))]
    public class TextGeneratorService : WavesService, ITextGeneratorService
    {
        private IRandomizerString _textRandomizer;
        private IRandomizerString _wordRandomizer;

        /// <inheritdoc />
        public string GenerateText()
        {
            return _textRandomizer.Generate();
        }

        /// <inheritdoc />
        public string GenerateWord()
        {
            return _wordRandomizer.Generate();
        }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return Task.CompletedTask;
            }

            _textRandomizer = new RandomizerTextLipsum(new FieldOptionsTextLipsum());
            _wordRandomizer = new RandomizerTextWords(new FieldOptionsTextWords { Max = 1 });

            IsInitialized = true;

            return Task.CompletedTask;
        }
    }
}
