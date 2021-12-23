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
    public partial class UserControlcook3 : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public UserControlcook3()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM cookcheck";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;

        }
        
        public void searchData(string valueToSearch)
        {
            
            
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from cookcheck where items like '" + textBox1.Text + "%' "; ;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable da = new DataTable();
                sda.Fill(da);
                dataGridView1.DataSource = da;
            
            
        }
        private void dataGridView1_Search_Load(object sender, DataGridViewCellEventArgs e)
        {
            searchData("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }
    }
}
