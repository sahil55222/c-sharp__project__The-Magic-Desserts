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
    public partial class Pre_Order : Form
    {
        public Pre_Order()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            method us = new method();
            us.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PreOrderPastry us = new PreOrderPastry();
            us.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           PreOrderCake us = new PreOrderCake();
            us.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           PreOrderSweets us = new PreOrderSweets();
            us.ShowDialog();
        }

        private void Pre_Order_Load(object sender, EventArgs e)
        {
            
        }
    }
}
