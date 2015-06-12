using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;

namespace Tiers.Service
{
    public interface IUserService
    {
        IList<UserDTO> GetAll();
        UserDTO Get(int id);
        UserDTO Get(string name);
        UserDTO Create(UserDTO newUser);
        UserDTO Update(UserDTO newUser);
        int Delete(int id);
    }
}
