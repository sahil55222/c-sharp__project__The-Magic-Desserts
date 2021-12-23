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
    public partial class UserControl2 : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public UserControl2()
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

        private void button3_Click(object sender, EventArgs e)
        {
            int input1 = int.Parse(priceTextBox.Text);
            int input2 = int.Parse(quantityTextBox.Text);
            int result = input1 * input2;

            //MessageBox.Show("Price is : " * result);
            totalTextBox.Text = "" + result;
            totalTextBox.Visible = true;
        }
        void ResetControl()
        {
            priceTextBox.Clear();
            quantityTextBox.Clear();
            totalTextBox.Clear();
            items_NameTextBox.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        public static string SetValueForText1 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Submit Your Information and Pay", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            PayManagerOpt us = new PayManagerOpt();
            SetValueForText1 = totalTextBox.Text;
            us.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            items_NameTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            priceTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
