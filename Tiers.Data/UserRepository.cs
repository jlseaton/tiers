using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Data
{
    public class UserRepository : IUserRepository
    {
        private int nextId = 1;

        private List<UserModel> users = new List<UserModel>();

        /// <summary>
        /// A simple memory based repository of users
        /// </summary>
        public UserRepository()
        {
            Create(new UserModel { Name = "User1", Data = 1.11 } );
            Create(new UserModel { Name = "User2", Data = 2.22 });
            Create(new UserModel { Name = "User3", Data = 3.33 });
            Create(new UserModel { Name = "User4", Data = 4.44 });
            Create(new UserModel { Name = "User5", Data = 5.55 });
        }

        public UserModel Get(int id)
        {
            return users.Find(u => u.ID == id);
        }

        public UserModel Get(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument name cannot be null or empty.");
            }

            return users.Find(u => u.Name == name);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return users;
        }

        public UserModel Create(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentException("Argument user cannot be null.");
            }
            
            user.ID = nextId++;
            users.Add(user);

            return user;
        }

        public UserModel Update(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentException("Argument user cannot be null.");
            }

            var existing = users.Find(u => u.ID == user.ID);
            if (existing != null) 
            {
                existing.ID = user.ID;
                existing.Name = user.Name;
                existing.Data = user.Data;
            }
            
            return existing;
        }

        public int Delete(int id)
        {
            return users.RemoveAll(u => u.ID == id);
        }
    }
}
