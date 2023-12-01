using Inlämning3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inlämning3
{
    /// <summary>
    /// Manages user-related operations.
    /// </summary>
    public class UserManager
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the "UserManager" class.
        /// </summary>
        /// <param name="database">The database interface for user operations.</param>
        public UserManager(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void AddUser(User user)
        {
            _database.AddUser(user);
        }

        /// <summary>
        /// Removes a user from the database based on the provided user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to remove.</param>
        /// <exception cref="ArgumentException">Thrown when the user does not exist.</exception>
        public void RemoveUser(int userId)
        {
            var existingUser = _database.GetUser(userId);

            if (existingUser == null)
            {
                throw new ArgumentException($"User with ID {userId} not found");
            }
            else
            {
                _database.RemoveUser(userId);
            }
        }

        /// <summary>
        /// Retrieves a user from the database based on the provided user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The retrieved user.</returns>
        /// <exception cref="ArgumentException">Thrown when the user does not exist.</exception>
        public User GetUser(int userId)
        {
            var user = _database.GetUser(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found");
            }
            return user;
        }
    }
}
