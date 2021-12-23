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
    public partial class order_offline : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public order_offline()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM update_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
        }
        void ResetControl()
        {
            priceTextBox.Clear();
            totalTextBox.Clear();
            items_NameTextBox.Clear();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int input1 = int.Parse(priceTextBox.Text);
            int input2 = int.Parse(comboBox1.Text);
            int result = input1 * input2;

            //MessageBox.Show("Price is : " * result);
            totalTextBox.Text = "" + result;
            totalTextBox.Visible = true;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            items_NameTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            priceTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login us = new login();
            us.ShowDialog();
        }
        public static string SetValueForText1 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (items_NameTextBox.Text != "" && priceTextBox.Text != "")
            {
                MessageBox.Show("Submit Your Information and Pay", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                pay_offline us = new pay_offline();
                SetValueForText1 = totalTextBox.Text;
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("fill the field", "fail to payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            offline us = new offline();
            us.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
    }
}
