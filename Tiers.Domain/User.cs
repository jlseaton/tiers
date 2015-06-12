using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;
using Tiers.Data;
using Tiers.Domain.Models;

namespace Tiers.Domain
{
    /// <summary>
    /// User business domain object
    /// </summary>
    public class User : Entity
    {
        private IUserRepository repository;

        /// <summary>
        /// Results of the last search operation
        /// </summary>
        public SearchResult LastSearchResult { get; private set; }

        public User()
        {
            repository = new UserRepository();
            
            LastSearchResult = new SearchResult();
        }

        public User(IUserRepository context)
        {
            if (context != null)
            {
                this.repository = (IUserRepository)context;
            }
            else
            {
                this.repository = new UserRepository();
            }

            LastSearchResult = new SearchResult();
        }

        /// <summary>
        /// Checks if an id is within a valid range
        /// </summary>
        /// <param name="id">Id to check</param>
        /// <returns>Nothing if valid or an invalid reason message</returns>
        public string IsValidID(int id)
        {
            if (id < 0 || id > Int16.MaxValue)
            {
                return "ID must be between 0 and " + Int16.MaxValue.ToString();
            }

            return String.Empty;
        }

        public IList<UserDTO> GetAll()
        {
            var users = from u in repository.GetAll()
                        select new UserDTO()
                        {
                            ID = u.ID,
                            Name = u.Name,
                            Data = u.Data
                        };
            return users.ToList();
        }

        public UserDTO Get(int id)
        {
            return repository.Get(id).ToDTO();
        }

        public UserDTO Get(string name)
        {
            return repository.Get(name).ToDTO();
        }

        public UserDTO Create(UserDTO user)
        {
            return repository.Create(
                new UserModel { 
                    ID = user.ID, 
                    Name = user.Name, 
                    Data = user.Data 
                }).ToDTO();
        }

        public UserDTO Update(UserDTO user)
        {
            return repository.Update(
                new UserModel { 
                    ID = user.ID, 
                    Name = user.Name, 
                    Data = user.Data 
                }).ToDTO();
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
