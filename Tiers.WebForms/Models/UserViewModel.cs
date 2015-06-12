using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tiers.Core;
using Tiers.Service;

namespace Tiers.WebForms
{
    public class UserViewModel
    {
        public List<UserDTO> Users { get; set; }
        public UserDTO User { set; get; }

        public string q { set; get; }

        public int RowCount { set; get; }
        public int PageSize { set; get; }

        public UserViewModel()
        {
            User = new UserDTO();
            Users = new List<UserDTO>();
            PageSize = 10;
        }
    }
}