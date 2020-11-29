﻿using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;

namespace Waves.UI.Showcase.Common.Services.Interfaces
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