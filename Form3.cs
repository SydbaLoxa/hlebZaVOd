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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
            string query = "SELECT * FROM break_history";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var dataAdapter = new NpgsqlDataAdapter(query, connection);
                var dataTable = new DataTable();


                //connection.Open();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //this.Close();
            //f1.Show();
        }

        private void account_Click(object sender, EventArgs e)
        {

        }
    }
}
