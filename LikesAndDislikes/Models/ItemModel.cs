namespace LikesAndDislikes.Models
{
    /// <summary>
    /// Used to group form data into item specific objects.
    /// </summary>
    public class ItemModel
    {
        public string Action { get; private set; }
        public string Option { get; private set; }
        public string Choice { get; private set; }

        /// <summary>
        /// Creates an <see cref="ItemModel"/> object.
        /// </summary>
        /// <param name="action">A <see cref="string"/> value representing which <see cref="ContentModel"/> list this item should be added to.</param>
        /// <param name="option">A <see cref="string"/> value containing one of the predetermined form options.</param>
        /// <param name="choice">A <see cref="string"/> value containing what the user chose to match the selected option.</param>
        /// <returns>The created <see cref="ItemModel"/> object.</returns>
        public ItemModel(string action, string option, string choice)
        {
            Action = action;
            Option = option;
            Choice = choice;
        }
    }
}
