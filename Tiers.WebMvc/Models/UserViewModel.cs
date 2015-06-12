using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiers.Core;
using Tiers.Service;

namespace Tiers.WebMvc.Models
{
    public class UserViewModel
    {
        public List<UserDTO> Users { get; set; }
        public UserDTO User { set; get; }

        public string Result { set; get; }

        public int RowCount { set; get; }
        public int PageSize { set; get; }

        private List<SelectListItem> pageSizes = new List<SelectListItem>();
        public List<SelectListItem> PageSizes
        {
            get
            {
                SelectListItem sli = 
                    pageSizes.Find(i => i.Value == PageSize.ToString());
                sli.Selected = true;
                return pageSizes;
            }
        }

        public UserViewModel()
        {
            User = new UserDTO();
            Users = new List<UserDTO>();

            PageSize = 10;
            pageSizes.Add(new SelectListItem() { Text = "10", Value = "10" });
            pageSizes.Add(new SelectListItem() { Text = "25", Value = "25" });
            pageSizes.Add(new SelectListItem() { Text = "50", Value = "50" });
            pageSizes.Add(new SelectListItem() { Text = "100", Value = "100" });
        }
    }
}