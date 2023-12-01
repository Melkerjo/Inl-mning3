using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inlämning3.Interfaces
{
    /// <summary>
    /// Interface for managing users.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Adds a user to the database.
        /// </summary>
        /// <param name="user">The user to add.</param>
        void AddUser(User user);

        /// <summary>
        /// Removes a user from the database based on the user ID.
        /// </summary>
        /// <param name="userId">The user ID to identify the user to be removed.</param>
        void RemoveUser(int userId);

        /// <summary>
        /// Retrieves a user from the database based on the user ID.
        /// </summary>
        /// <param name="userId">The user ID to identify the user to be retrieved.</param>
        /// <returns>The user if found, otherwise null.</returns>
        User GetUser(int userId);
    }
}

