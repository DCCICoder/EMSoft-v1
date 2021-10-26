using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EMSoft
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itdcc\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Fetchempdata();
        }
        private void Fetchempdata()
        {
            Con.Open();
            string query = "select * from Emp where EmpID ='" + EmpIDTB.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmpIDLbl.Text = dr["EmpID"].ToString();
                EmpNameLbl.Text = dr["FullName"].ToString();
                EmpContactNoLbl.Text = dr["ContactNo"].ToString();
                EmpAadharNoLbl.Text = dr["AadharNo"].ToString();
                EmpEmailLbl.Text = dr["EmailID"].ToString();
                EmpPANLbl.Text = dr["PANNo"].ToString();
                EmpCommunicationAddLbl.Text = dr["CommunicationAdd"].ToString();
                EmpFatherLbl.Text = dr["Father"].ToString();
                EmpMotherLbl.Text = dr["Mother"].ToString();
                EmpParentContactLbl.Text = dr["ParentsContactNo"].ToString();
                EmpBGroupLbl.Text = dr["BloodGroup"].ToString();
                EmpBankACLbl.Text = dr["BankACNo"].ToString();
                EmpIFSCLbl.Text = dr["IFSCCode"].ToString();
                EmpPermanentAddLbl.Text = dr["PermanentAdd"].ToString();
                Empdojlbl.Text = dr["DOJ"].ToString();
                EmpPoslbl.Text = dr["Position"].ToString();
                EmpIDLbl.Visible = true;
                EmpNameLbl.Visible = true;
                EmpContactNoLbl.Visible = true;
                EmpAadharNoLbl.Visible = true;
                EmpEmailLbl.Visible = true;
                EmpPANLbl.Visible = true;
                EmpCommunicationAddLbl.Visible = true;
                EmpFatherLbl.Visible = true;
                EmpMotherLbl.Visible = true;
                EmpParentContactLbl.Visible = true;
                EmpBGroupLbl.Visible = true;
                EmpBankACLbl.Visible = true;
                EmpIFSCLbl.Visible = true;
                EmpPermanentAddLbl.Visible = true;
                EmpPoslbl.Visible = true;
                Empdojlbl.Visible = true;
            }
            Con.Close();
        }
        private void View_Load(object sender, EventArgs e)
        {
            EmpCommunicationAddLbl.MaximumSize = new Size(300, 0);
            EmpPermanentAddLbl.MaximumSize = new Size(300, 0);
            EmpCommunicationAddLbl.AutoSize = true;
            EmpPermanentAddLbl.AutoSize = true;
        }

        private void EmpCommunicationAddLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            EmpCommunicationAddLbl.MaximumSize = new Size(300,0);
            EmpCommunicationAddLbl.AutoSize = true;
        }
    }
}
