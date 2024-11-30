using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace опд1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        string id;
        string fkId;
        string time;
        string weight;
        string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
        string queryScale = "SELECT * FROM scales";


        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM plan";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var dataAdapter = new NpgsqlDataAdapter(query, connection);
                var dataTable = new DataTable();


                //connection.Open();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                //*********************************************************
                
                var dataAdapter2 = new NpgsqlDataAdapter(queryScale, connection);
                var dataTable2 = new DataTable();


                //connection.Open();
                dataAdapter2.Fill(dataTable2);
                dataGridView2.DataSource = dataTable2;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.Width = 70; // Устанавливаем ширину каждого столбца в 100 пикселей
                }
            }
            dataGridView1.Columns[0].Visible = false;
            


        }

        private void exit_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //this.Close();
            //f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            id       = textBoxId.Text;
            fkId     = textBoxLId.Text;
            time     = textBoxTime.Text;
            weight   = textBoxWeight.Text;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                string queryInScale = "INSERT INTO scales (id, fk_line_id,time_,weight_out) VALUES (@id1, @fk_line_id,@time_,@weight_out)";
                string queryInEq = "UPDATE equimpet SET probeg = probeg + @weight_out WHERE fk_line_id = 1";

                using (var command = new NpgsqlCommand(queryInEq, connection))
                {
                    connection.Open(); // Открываем соединение

                    int weight2 = int.Parse(weight); // Преобразуем строку в целое число
                    command.Parameters.AddWithValue("@weight_out", NpgsqlTypes.NpgsqlDbType.Integer, weight2);

                    int rowsAffected = command.ExecuteNonQuery(); // Выполняем команду
                    Console.WriteLine($"{rowsAffected} row(s) inserted."); // Выводим количество вставленных строк
                }


                using (var command = new NpgsqlCommand(queryInScale, connection))
                {
                    int id2 = int.Parse(id);
                    int fkid2 = int.Parse(fkId);
                    DateTime time2 = DateTime.Parse(time);
                    int weight22 = int.Parse(weight);
                    command.Parameters.AddWithValue("@id1", NpgsqlTypes.NpgsqlDbType.Integer, id2);
                    command.Parameters.AddWithValue("@fk_line_id", NpgsqlTypes.NpgsqlDbType.Integer, fkid2);
                    command.Parameters.AddWithValue("@time_", NpgsqlTypes.NpgsqlDbType.Timestamp, time2);
                    command.Parameters.AddWithValue("@weight_out", NpgsqlTypes.NpgsqlDbType.Integer, weight22);



                    try
                    {
                        //connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} запись(и) добавлена(ы).");
                        var dataAdapter2 = new NpgsqlDataAdapter(queryScale, connection);
                        var dataTable2 = new DataTable();


                        //connection.Open();
                        dataAdapter2.Fill(dataTable2);
                        dataGridView2.DataSource = dataTable2;
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            column.Width = 70; // Устанавливаем ширину каждого столбца в 100 пикселей
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxLId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
