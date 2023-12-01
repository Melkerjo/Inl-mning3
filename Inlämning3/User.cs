using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inlämning3
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user's ID.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class with the specified details.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="userName">The user's username.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="email">The user's email.</param>
        public User(int userId, string userName, string password, string email)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}

