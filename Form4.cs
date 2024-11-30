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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace опд1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string id;
        string weight;
        string date;
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
            dataGridView1.Columns[0].Visible = false;
            //dataGridView2.Columns[0].Visible = false;
            dataGridView3.Columns[0].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = textBoxId.Text;
            weight = textBoxWeight.Text;
            date = textBoxTime.Text;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                string queryInEmpl = "INSERT INTO for_employers (id,weight_defect_product,what_date) VALUES (@id, @weight_defect_product, @what_date)";

                using (var command = new NpgsqlCommand(queryInEmpl, connection))
                {
                    int id2 = int.Parse(id);
                    DateTime date2 = DateTime.Parse(date);
                    int weight22 = int.Parse(weight);
                    command.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Integer, id2);
                    command.Parameters.AddWithValue("@what_date", NpgsqlTypes.NpgsqlDbType.Timestamp, date2);
                    command.Parameters.AddWithValue("@weight_defect_product", NpgsqlTypes.NpgsqlDbType.Integer, weight22);



                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} запись(и) добавлена(ы).");
                        var dataAdapter2 = new NpgsqlDataAdapter(queryEmployer, connection);
                        var dataTable2 = new DataTable();


                        //connection.Open();
                        dataAdapter2.Fill(dataTable2);
                        dataGridView2.DataSource = dataTable2;
                        //foreach (DataGridViewColumn column in dataGridView2.Columns)
                        //{
                            //column.Width = 70; // Устанавливаем ширину каждого столбца в 100 пикселей
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
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

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
