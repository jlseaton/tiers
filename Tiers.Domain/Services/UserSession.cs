using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;
using Tiers.Data;

namespace Tiers.Domain.Services
{
    /// <summary>
    /// A not so useful example of a domain service to login/logout users
    /// </summary>
    public class UserSession : IUserSession
    {
        private User _user = new User();

        public UserSession(User user)
        {
            this._user = user;
        }

        public virtual User GetCurrentUser()
        {
            return _user;
        }

        public void LogIn(User user)
        {
            _user = user;
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
