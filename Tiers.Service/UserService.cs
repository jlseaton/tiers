using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tiers.Core;
using Tiers.Domain;

namespace Tiers.Service
{
    /// <summary>
    /// Service for User domain functions, returns DTOs/statuses to consumers
    /// </summary>
    public class UserService : IUserService
    {
        private User user = new User();

        /// <summary>
        /// Results of the last search operation
        /// </summary>
        public SearchResult LastSearchResult
        {
            get
            {
                return user.LastSearchResult;
            }
        }

        // The service layer allows for default or injected user domain objects
        public UserService()
        {
        }

        public UserService(User user)
        {
            this.user = user;
        }
        
        public IList<UserDTO> GetAll()
        {
            // We're repeating what the domain does, but this time skipping data
            // to show how the service layer might render different data to
            // less secure consumers for example
            var users = from u in user.GetAll()
                        select new UserDTO
                        {
                            ID = u.ID,
                            Name = u.Name
                            // Skip sensitive data field
                        };
            return users.ToList();
        }

        // The remaining methods just pass along data from the domain calls

        public UserDTO Get(int id)
        {
            string valid = user.IsValidID(id);

            if (!String.IsNullOrEmpty(valid))
            {
                throw new ArgumentException(valid);
            }

            return user.Get(id); 
        }

        public UserDTO Get(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Parameter name must have a value");
            }

            return user.Get(name);
        }

        public UserDTO Create(UserDTO newUser)
        {
            if (newUser == null || String.IsNullOrEmpty(newUser.Name))
            {
                throw new ArgumentException(
                    "Parameter newUser must have a value and a name field");
            }

            return user.Create(newUser);
        }

        public UserDTO Update(UserDTO newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentException(
                    "Parameter newUser must have a value");
            }

            string valid = user.IsValidID(newUser.ID);

            if (!String.IsNullOrEmpty(valid))
            {
                throw new ArgumentException(valid);
            }

            return user.Update(newUser);
        }

        public int Delete(int id)
        {
            return user.Delete(id);
        }
    }
}
