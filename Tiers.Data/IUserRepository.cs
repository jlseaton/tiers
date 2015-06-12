using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Data
{
    public interface IUserRepository
    {
        UserModel Get(int id);
        UserModel Get(string name);

        IEnumerable<UserModel> GetAll();
        
        UserModel Create(UserModel user);

        UserModel Update(UserModel user);

        int Delete(int id);
    }
}
