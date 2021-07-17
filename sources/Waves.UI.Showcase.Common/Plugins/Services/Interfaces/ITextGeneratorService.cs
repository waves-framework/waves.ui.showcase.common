using Waves.Core.Base.Interfaces;

namespace Waves.UI.Showcase.Common.Plugins.Services.Interfaces
{
    /// <summary>
    ///     Interface for text generator.
    /// </summary>
    public interface ITextGeneratorService : IWavesService
    {
        /// <summary>
        ///     Generates text.
        /// </summary>
        /// <returns>Generated text.</returns>
        string GenerateText();

        /// <summary>
        ///     Generates word.
        /// </summary>
        /// <returns>Generated word.</returns>
        string GenerateWord();
    }
}
