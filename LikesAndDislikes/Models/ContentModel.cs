namespace LikesAndDislikes.Models
{
    /// <summary>
    /// Used to group content data, such as <see cref="ItemModel"/>s, into user specific objects.
    /// </summary>
    public class ContentModel
    {
        public string Username { get; private set; }
        public List<ItemModel> Likes { get; set; }
        public List<ItemModel> Dislikes { get; set; }

        /// <summary>
        /// Creates a <see cref="ContentModel"/> object.
        /// </summary>
        /// <param name="user">A <see cref="string"/> value containing the username of the user whose content this is.</param>
        /// <returns>The created <see cref="ContentModel"/> object.</returns>
        public ContentModel(string user)
        {
            Username = user;
            Likes = new List<ItemModel>();
            Dislikes = new List<ItemModel>();
        }
    }
}
