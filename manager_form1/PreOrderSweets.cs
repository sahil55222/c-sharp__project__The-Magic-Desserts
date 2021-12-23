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
    public partial class PreOrderSweets : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public PreOrderSweets()
        {
            InitializeComponent();
            BindGridView();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pre_Order us = new Pre_Order();
            us.ShowDialog();
        }
        public static string SetValueForText2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (items_NameTextBox.Text != "" && priceTextBox.Text != "")
            {
                MessageBox.Show("Submit Your Information and Pay", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                B us = new B();
                SetValueForText2 = totalTextBox1.Text;
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("fill the field", "fail to payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM preordersweets";
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

            totalTextBox1.Clear();
            items_NameTextBox.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login us = new login();
            us.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int input1 = int.Parse(priceTextBox.Text);
            int input2 = int.Parse(comboBox1.Text);
            int result = input1 * input2;

            //MessageBox.Show("Price is : " * result);
            totalTextBox1.Text = "" + result;
            totalTextBox1.Visible = true;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            items_NameTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            priceTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
