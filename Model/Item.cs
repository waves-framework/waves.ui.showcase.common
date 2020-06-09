using Waves.Core.Base;

namespace Waves.UI.Showcase.Common.Model
{
    /// <summary>
    ///     Item.
    /// </summary>
    public class Item : ObservableObject
    {
        /// <summary>
        ///     Creates new instance of Item.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        ///     Gets name of item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets description.
        /// </summary>
        public string Description { get; }
    }
}