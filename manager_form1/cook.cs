using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manager_form1
{
    public partial class cook : Form
    {
        public cook()
        {
            InitializeComponent();
        }

        private void cook_Load(object sender, EventArgs e)
        {
            userControlcook11.Hide();
            userControlcook21.Hide();
            userControlcook31.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControlcook11.Hide();
            userControlcook21.Hide();
            // Show current user control
            userControlcook31.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControlcook21.Hide();
            userControlcook31.Hide();
            // Show current user control
            userControlcook11.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControlcook11.Hide();
            userControlcook31.Hide();
            // Show current user control
            userControlcook21.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Successful & back login page ");
            this.Hide();
            login_method us = new login_method();
            us.ShowDialog();
        }
    }
}
