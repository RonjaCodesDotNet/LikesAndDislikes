namespace LikesAndDislikes.Models
{
    /// <summary>
    /// Used to keep track of and make changes to all the user accounts and their contents.
    /// </summary>
    public static class AccountsModel
    {
        private static Dictionary<string, string> loginCredentials = new();
        private static List<ContentModel> userContent = new();

        /// <summary>
        /// Adds login credentials for a new user.
        /// </summary>
        /// <param name="createUser">The <see cref="UserModel"/> object to be added.</param>
        /// <returns>A <see cref="bool"/> value that represents whether or not the user was successfully added.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="createUser"/> is <c>null</c>.
        /// </exception>
        public static bool CreateUser(UserModel createUser)
        {
            try
            {
                if (loginCredentials.ContainsKey(createUser.Username)) return false;
                else
                {
                    loginCredentials.Add(createUser.Username, createUser.Password);
                    return true;
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Exception occurred at {ex.Source}");
            }

            return false;
        }

        /// <summary>
        /// Confirms that the username of a saved <see cref="UserModel"/> object matches its password.
        /// </summary>
        /// <param name="loginUser">The <see cref="UserModel"/> object to be confirmed.</param>
        /// <returns>A <see cref="bool"/> value that represents whether or not the confirmation succeeded.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="loginUser"/> is <c>null</c>.
        /// </exception>
        public static bool ConfirmUser(UserModel loginUser)
        {
            try
            { 
                if (loginCredentials.ContainsKey(loginUser.Username))
                {
                    return (loginCredentials[loginUser.Username] == loginUser.Password);
                }
                else return false;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Exception occurred at {ex.Source}");
            }

            return false;
        }

        /// <summary>
        /// Adds content to an existing user.
        /// </summary>
        /// <param name="addUsername">A <see cref="string"/> value containing the username of the user that's having content added.</param>
        /// <param name="addItem">An <see cref="ItemModel"/> object containing the content to be added.</param>
        /// <returns>A <see cref="bool"/> value which confirms that the content was successfully added.</returns>
        public static bool AddToUser(string addUsername, ItemModel addItem)
        {
            foreach (ContentModel item in userContent)
            {
                if (addUsername == item.Username)
                {
                    if (addItem.Action == "Gilla") item.Likes.Add(addItem);
                    else if (addItem.Action == "Ogilla") item.Dislikes.Add(addItem);

                    return true;
                }
            }

            ContentModel thisUser = new(addUsername);

            if (addItem.Action == "Gilla") thisUser.Likes.Add(addItem);
            else if (addItem.Action == "Ogilla") thisUser.Dislikes.Add(addItem);

            userContent.Add(thisUser);

            return true;
        }

        /// <summary>
        /// Checks if a <see cref="UserModel"/> object with the specified username exists.
        /// </summary>
        /// <param name="searchUsername">A <see cref="string"/> value containing the username to be searched for.</param>
        /// <returns>A <see cref="bool"/> value that represents whether or not the user exists.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="searchUsername"/> is <c>null</c>.
        /// </exception>
        public static bool SearchUser(string searchUsername)
        {
            try
            {
                return loginCredentials.ContainsKey(searchUsername);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Exception occurred at {ex.Source}");
            }

            return false;
        }

        /// <summary>
        /// Retrieves a saved <see cref="ContentModel"/> object to be displayed.
        /// </summary>
        /// <param name="displayUsername">A <see cref="string"/> value containing the username of the user whose content will be displayed.</param>
        /// <returns>The <see cref="ContentModel"/> object for the specified user, if one exists. Otherwise it returns <c>null</c>.</returns>
        public static ContentModel? DisplayContent(string displayUsername)
        {
            foreach (ContentModel displayItem in userContent)
            {
                if (displayItem.Username == displayUsername) return displayItem;
            }

            return null;
        }
    }
}
