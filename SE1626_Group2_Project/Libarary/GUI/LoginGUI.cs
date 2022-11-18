using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;

namespace Libarary.GUI
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbPass.Text == "" && tbUser.Text == "")
            {
                MessageBox.Show("Please enter your username and password");
                return;
            }
            var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var adminaccount = conf.GetSection("AdminAccount");
            string user = adminaccount["user"];
            string pass = adminaccount["pass"];
            if (tbPass.Text == pass && tbUser.Text == user)
            {
                this.Hide();
                var main = new MainGUI();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
