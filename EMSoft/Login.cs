using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void EmpID_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
           if(TxtEmpID.Text == "Admin" && TxtPassword.Text == "admin")
           {
                Home home = new Home();
                home.Show();
                this.Hide();
           }
           else
           {
                MessageBox.Show("Authenticate Yourself to Login", "EMSOft");
           }
        }
    }
}
