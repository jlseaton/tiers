using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tiers.Service;

namespace Tiers.WinForms
{
    public partial class TiersTest : Form
    {
        public TiersTest()
        {
            InitializeComponent();
            
            GetRandomUser();
        }

        private void GetRandomUser()
        {
            try
            {
                var user = new UserService().Get(new Random().Next(5) + 1);
                this.textBox1.Text = String.Format("ID: {0}, Name:{1}, Data:{2:0.##}", user.ID, user.Name, user.Data.ToString());
            }
            catch (Exception ex)
            {
                this.textBox2.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UserWebApiClient client = new UserWebApiClient();
                this.textBox2.Text = client.Get();
                
                GetRandomUser();
            }
            catch (Exception ex)
            {
                this.textBox2.Text = ex.Message;
            }
        }
    }
}
