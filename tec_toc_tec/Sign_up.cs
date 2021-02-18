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
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Login objlo = new Login();
            this.Hide();
            objlo.Show(); 
        }

        private void Create(object sender, EventArgs e)
        {
            int a = 0;
            a=Names.TextLength;
            int b = 0;
            b=Passwords.TextLength;
            if (a > 0 && b > 0)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Login.mdf;Integrated Security=True;Connect Timeout=30");
                sqlcon.Open();
                SqlDataAdapter data = new SqlDataAdapter("INSERT INTO login (Name,Password) VALUES('" + Names.Text + "','" + Passwords.Text + "');", sqlcon);
                data.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Created");
                sqlcon.Close();
                Login objlo = new Login();
                this.Hide();
                objlo.Show();
            }
            else
            {
                MessageBox.Show("Insert Value First");
            }

        }
    }
}
