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

namespace tec_toc_tec
{
    public partial class Login : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Login.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
        }

        private void Log(object sender, EventArgs e)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter(@"select * from login where Name='" + textuser.Text + "' and Password ='" + textpassword.Text + "'",sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Main objMain = new Main();
                this.Hide();
                objMain.Show();
            }
            else
            {
                MessageBox.Show("Incorrect User Name Passward");
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sign_up(object sender, EventArgs e)
        {
            Sign_up objUp = new Sign_up();
            this.Hide();
            objUp.Show();
        }
    }
}
