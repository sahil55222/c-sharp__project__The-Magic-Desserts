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
    public partial class UserControl4 : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
        public UserControl4()
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update update_tbl set id=@id,catagory=@catagory,items=@items,price=@price where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@catagory", textBox1.Text);
            cmd.Parameters.AddWithValue("@items", textBox2.Text);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Updated");

            }


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
