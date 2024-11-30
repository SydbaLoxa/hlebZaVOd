using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace опд1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string id;
        string what_date;
        string product_plan;
        string product_real_quantity;
        string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
        string queryEmployer = "SELECT * FROM for_employers";


        private void Form4_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users";
            string queryPlan = "SELECT * FROM plan";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var dataAdapter = new NpgsqlDataAdapter(query, connection);
                var dataTable = new DataTable();


                //connection.Open();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                //*********************************************************

                var dataAdapter2 = new NpgsqlDataAdapter(queryEmployer, connection);
                var dataTable2 = new DataTable();


                //connection.Open();
                dataAdapter2.Fill(dataTable2);
                dataGridView2.DataSource = dataTable2;
                //*********************************************************

                var dataAdapter3 = new NpgsqlDataAdapter(queryPlan, connection);
                var dataTable3 = new DataTable();


                //connection.Open();
                dataAdapter3.Fill(dataTable3);
                dataGridView3.DataSource = dataTable3;
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            this.Close();
            //f1.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //сюда пишем табличку for_employer
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
