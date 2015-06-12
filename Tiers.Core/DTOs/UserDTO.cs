using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    //[Serializable] // Normally on, but its off to avoid "Backing field" in data
    public class UserDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public double Data { get; set; }
    }
}