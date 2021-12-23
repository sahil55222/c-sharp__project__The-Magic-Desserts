using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace manager_form1
{
    public partial class login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "" && textBox2.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from userid1 where username = @user and pass= @pass ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                con.Open();
                SqlDataReader kar = cmd.ExecuteReader();
                if (kar.HasRows == true)
                {
                    MessageBox.Show("login Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    login_method us = new login_method();
                    us.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("login fail", "fail to log in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("fill the field", "fail to log in", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            about_us us = new about_us();
            us.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into userid1 values (@username,@pass)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Sign In Successfully");
              
            }
            else
            {
                MessageBox.Show("Please try again!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            method us = new method();
            us.ShowDialog();
        }
    }
}
