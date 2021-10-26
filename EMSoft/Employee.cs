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
using Microsoft.Office.Interop;



namespace EMSoft
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itdcc\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(EmpID.Text == "" || EmpName.Text == "" || EmpFather.Text == "" || EmpMother.Text == "")
            {
                MessageBox.Show("Please Enter the Details to be Added.....","EMSoft");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Emp values('"+EmpID.Text.ToString().ToUpper().Trim()+"','"+EmpName.Text.ToString().Trim()+ "','" + EmpFather.Text.ToString().Trim() + "','" + EmpMother.Text.ToString().Trim() 
                        + "','" + EmpContactNo.Text.ToString().Trim() + "','" + EmpParentContactNo.Text.ToString().Trim() + "','" + EmpAadhar.Text.ToString().Trim() + "','" + EmpPAN.Text.ToString().ToUpper()+ "','" + 
                        EmpBank.Text.ToString().Trim()+ "','" + EmpIFSC.Text.ToString().ToUpper() + "','" + EmpEmail.Text.ToString().Trim()+ "','" + EmpBGroup.Text.ToString().Trim() + "','" + EmpPermanentAdd.Text + "','" 
                        + EmpCommunicationAdd.Text + "','" + EmpDoj.Value.Date.ToString().Trim() + "','" + EmpPos.Text.ToString().Trim() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added Successfully !");
                    Con.Close();
                    Populate();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                    Populate();
                    Clear();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Populate()
        {
            Con.Open();
            string query = "select * from Emp";
            SqlDataAdapter Sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(Sda);
            var ds = new DataSet();
            Sda.Fill(ds);
            DgvEmp.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            EmpID.Text = EmpName.Text = EmpContactNo.Text = EmpParentContactNo.Text = EmpAadhar.Text = EmpBank.Text = 
            EmpCommunicationAdd.Text = EmpEmail.Text = EmpFather.Text =
            EmpIFSC.Text = EmpMother.Text = EmpPAN.Text = EmpPermanentAdd.Text = "";
            EmpBGroup.SelectedIndex = -1;
            EmpPos.SelectedIndex = -1;
            BtnUpdate.Visible = false;
            BtnAdd.Enabled = true;
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DgvEmp.AutoGenerateColumns = false;
            Populate();
            Clear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(EmpID.Text == "")
            {
                MessageBox.Show("Enter Employee ID to Remove....");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Emp where EmpID='" + EmpID.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully..!");
                    Con.Close();
                    Populate();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                    Clear();
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (EmpID.Text == "" )
            {
                MessageBox.Show("Enter Employee Id Which you have to Edit...");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query1 = "Select * from Emp where EmpID ='" + EmpID.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmpID.Text = dr["EmpID"].ToString();
                        EmpName.Text = dr["FullName"].ToString();
                        EmpFather.Text = dr["Father"].ToString();
                        EmpMother.Text = dr["Mother"].ToString();
                        EmpContactNo.Text = dr["ContactNo"].ToString();
                        EmpParentContactNo.Text = dr["ParentsContactNo"].ToString();
                        EmpBGroup.Text = dr["BloodGroup"].ToString();
                        EmpEmail.Text = dr["EmailID"].ToString();
                        EmpPos.Text = dr["Position"].ToString();
                        EmpAadhar.Text = dr["AadharNo"].ToString();
                        EmpPAN.Text = dr["PANNo"].ToString();
                        EmpBank.Text = dr["BankACNo"].ToString();
                        EmpIFSC.Text = dr["IFSCCode"].ToString();
                        EmpPermanentAdd.Text = dr["PermanentAdd"].ToString();
                        EmpCommunicationAdd.Text=dr["CommunicationAdd"].ToString();
                    }
                    Con.Close();
                    BtnAdd.Enabled = false;
                    BtnUpdate.Visible = true;
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
                
            }
            
        }

        private void DgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmpName.Text != "")
                {
                    Con.Open();
                    string query = "update Emp set FullName ='"+EmpName.Text+ "',Father ='" + EmpFather.Text + "',Mother ='" + EmpMother.Text + "',ContactNo ='" + EmpContactNo.Text 
                        + "',ParentsContactNo ='" + EmpParentContactNo.Text + "',AadharNo='" + EmpAadhar.Text + "',PANNo ='" + EmpPAN.Text + "',EmailID ='" + EmpEmail.Text  
                        + "',BankACNo ='" + EmpBank.Text + "',IFSCCode ='" + EmpIFSC.Text + "',PermanentAdd ='" + EmpPermanentAdd.Text + "',CommunicationAdd='" + EmpCommunicationAdd.Text 
                        + "',DOJ ='" + EmpDoj.Text + "',Position ='" + EmpPos.Text + "',BloodGroup ='" + EmpBGroup.Text + "' Where EmpID = '"+EmpID.Text+"' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Updated Successfully !");
                    Populate();
                    Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Emp";
            SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, Con);
            DataTable Dt = new DataTable();
            sda.Fill(Dt);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xls)|*.xls";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.CreatePrompt = true;
            sfd.Title = "Save Exported File to ...";
            Microsoft.Office.Interop.Excel.Application Xl = new Microsoft.Office.Interop.Excel.Application();
            Xl.Application.Workbooks.Add(Dt);
            Xl.Columns.ColumnWidth = 30;
            Xl.ActiveWorkbook.SaveCopyAs(sfd.ShowDialog());
            Xl.ActiveWorkbook.Saved = true;
            Xl.Quit();
            Con.Close();
        }
    }
}
