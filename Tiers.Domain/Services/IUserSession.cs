using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Domain.Services
{
    public interface IUserSession
    {
        User GetCurrentUser();
        void LogIn(User user);
        void LogOut();
    }
}
