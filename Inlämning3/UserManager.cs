using Inlämning3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning3
{
    public class UserManager 
    { 

        private readonly IDatabase _database;

        public UserManager(IDatabase database)
        {
            _database = database;
        }

        public void AddUser(User user)
        {
            _database.AddUser(user);
        }

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
