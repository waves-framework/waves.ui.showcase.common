using System;
using System.Composition;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.Services
{
    /// <summary>
    ///     Text generator service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class TextGeneratorService : WavesService, ITextGeneratorService
    {
        private IRandomizerString _loremIpsumRandomizer;
        private IRandomizerString _wordRandomizer;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("7698A027-EE52-48A9-A6F9-2917A9FA6142");

        /// <inheritdoc />
        public override string Name { get; set; } = "Text generator service";

        /// <inheritdoc />
        public override void Initialize(IWavesCore core)
        {
            if (IsInitialized) return;

            Core = core;

            _loremIpsumRandomizer = new RandomizerTextLipsum(new FieldOptionsTextLipsum());
            _wordRandomizer = new RandomizerTextWords(new FieldOptionsTextWords {Max = 1});

            OnMessageReceived(this,
                new WavesMessage("Initialization", "Service was initialized.", Name, WavesMessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration()
        {
            //
        }

        /// <inheritdoc />
        public override void SaveConfiguration()
        {
            //
        }

        /// <inheritdoc />
        public string GenerateText()
        {
            return _loremIpsumRandomizer.Generate();
        }

        /// <inheritdoc />
        public string GenerateWord()
        {
            return _wordRandomizer.Generate();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            _loremIpsumRandomizer = null;
        }
    }
}