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
    public partial class Paycheck : Form
    {
        public Paycheck()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
