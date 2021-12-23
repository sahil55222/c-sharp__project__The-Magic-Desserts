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

    public partial class UserControl6 : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public UserControl6()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM allpaymenttbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;

        }
        Boolean flag;
        public void searchData(string valueToSearch)
        {
            if (flag == false)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from allpaymenttbl where name like '" + textBox1.Text + "%' "; ;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable da = new DataTable();
                sda.Fill(da);
                dataGridView1.DataSource = da;
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from allpaymenttbl where review like '" + textBox1.Text + "%' "; ;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable da = new DataTable();
                sda.Fill(da);
                dataGridView1.DataSource = da;
            }
        }
        private void dataGridView1_Search_Load(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                flag = false;
                labelToSet.Text = "Enter Customer Name";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                flag = true;
                labelToSet.Text = "Enter Review";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
