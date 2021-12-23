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
using DGVPrinterHelper;

namespace manager_form1
{
    public partial class C : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public C()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pre_Order us = new Pre_Order();
            us.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query1 = "select * from reftable1 where Reference= @reference";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@reference", textBox6.Text);
            con.Open();
            SqlDataReader kar = cmd2.ExecuteReader();
            //con.Open();
            if (kar.HasRows == true)
            {


                string query = "insert into allpaymenttbl values (@name,@phone,@email,@price,@payment,@location,@review)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@payment", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@review", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@location", textBox4.Text);
                cmd.Parameters.AddWithValue("@price", textBox5.Text);
                guna2DataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox8.Text, comboBox2.SelectedItem);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();
                //con.Open();
                //cmd.ExecuteNonQuery();

                MessageBox.Show("Payment Successful");

            }
            else
            {
                MessageBox.Show("Reference no not found", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        Boolean flag;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                flag = false;

                label4.Text = "Ref No. Bkash";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                flag = true;
                label4.Text = "Ref No. Nagad";
            }
        }

        private void C_Load(object sender, EventArgs e)
        {
            textBox5.Text = PreOrderPastry.SetValueForText5;
           

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            int input1 = int.Parse(textBox5.Text);
            int input2 = int.Parse(textBox7.Text);
            int result = input1 - input2;

            //MessageBox.Show("Price is : " * result);
            textBox8.Text = "" + result;
            textBox8.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "The Magic Desserts";
            printer.SubTitle = "Customer Bill";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount: " + textBox8.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            // total = 0;
            guna2DataGridView1.Rows.Clear();
            // labelTotalAmount.Text = "Tk." + total;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
