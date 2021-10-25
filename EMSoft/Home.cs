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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            this.Hide();
            employee.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            this.Hide();
            employee.Show();
        }

        private void LblLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            View view = new View();
            this.Hide();
            view.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            View view = new View();
            this.Hide();
            view.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Paycheck paycheck = new Paycheck();
            this.Hide();
            paycheck.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Paycheck paycheck = new Paycheck();
            this.Hide();
            paycheck.Show();
        }
    }
}
