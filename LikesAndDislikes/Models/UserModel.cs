namespace LikesAndDislikes.Models
{
    /// <summary>
    /// Used to group login data into user specific objects.
    /// </summary>
    public class UserModel
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Creates a <see cref="UserModel"/> object.
        /// </summary>
        /// <param name="username">A <see cref="string"/> value containing the username to be saved.</param>
        /// <param name="password">A <see cref="string"/> value containing the password to be saved.</param>
        /// <returns>The created <see cref="UserModel"/> object.</returns>
        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}