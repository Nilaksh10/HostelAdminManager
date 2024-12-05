using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminHostelManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "123456";
            string entered_username = usernameTextbox.Text;
            string entered_password = passwordTextbox.Text;
            if(entered_username==username&& entered_password == password)
            {
                MessageBox.Show("Login Successfull");
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
