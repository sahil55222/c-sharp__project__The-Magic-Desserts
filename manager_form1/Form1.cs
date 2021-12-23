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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
            // Show current user control
            userControl11.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl11.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
            // Show current user control
            userControl21.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl11.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Hide();
            // Show current user control
            userControl31.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl51.Hide();
            userControl61.Hide();
            // Show current user control
            userControl41.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl61.Hide();
            // Show current user control
            userControl51.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Hide other user controls
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            // Show current user control
            userControl61.Show();
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
