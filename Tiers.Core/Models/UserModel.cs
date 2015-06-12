using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;

namespace Tiers.Data
{
    public class UserModel
    {
        /// <summary>
        /// Unique User ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Non-unique User's name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Pretend sensitive data
        /// </summary>
        public double Data { get; set; }

        /// <summary>
        /// Example field that is excluded in DTOs
        /// </summary>
        private SearchRequest request = new SearchRequest();

        public UserDTO ToDTO()
        {
            return new UserDTO()
            {
                ID = ID,
                Name = Name,
                Data = Data
            };
        }
    }
}
