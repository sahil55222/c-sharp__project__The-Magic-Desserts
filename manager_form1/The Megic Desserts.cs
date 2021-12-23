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
    public partial class The_Megic_Desserts : Form
    {
        public The_Megic_Desserts()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panel1.Width += 2;
            if (panel1.Width >= 499)
            {
                timer1.Stop();
                login fm = new login();
                fm.Show();
                this.Hide();
            }
        }

        private void The_Megic_Desserts_Load(object sender, EventArgs e)
        {

        }
    }
}
