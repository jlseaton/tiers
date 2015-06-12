using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tiers.Service;

namespace Tiers.WebForms
{
    public partial class _Default : Page
    {
        public UserViewModel model = new UserViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateUsers();
            }
        }

        private void UpdateUsers()
        {
            model.Users = new UserService().GetAll().ToList();
            model.User = new UserService().Get(new Random().Next(5) + 1);

            userRepeater.DataSource = model.Users;
            userRepeater.DataBind();
        }

        protected void buttonWebApi_Click(object sender, EventArgs e)
        {
            var users = new UserWebApiClient().Get();
            this.textBoxWebApiResult.Text = users;
            
            UpdateUsers();
        }
    }
}