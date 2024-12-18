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
using Microsoft.Office.Interop.Word;
using System.IO;

namespace опд1
{
    public partial class Form3 : Form
    {

        private Timer timer; // Таймер для обновления таблицы


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Подключение и загрузка данных при открытии формы
            LoadData();

            // Настройка таймера для обновления таблицы
            timer = new Timer();
            timer.Interval = 60000; // Интервал 1 минута (60000 миллисекунд)
            timer.Tick += Timer_Tick;
            timer.Start();
            /*string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
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
            dataGridView1.Columns[0].Visible = false;*/
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновление данных каждые 60 секунд
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
            string query = "SELECT * FROM break_history";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var dataAdapter = new NpgsqlDataAdapter(query, connection);
                var dataTable = new System.Data.DataTable();


                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dataGridView1.Columns[0].Visible = false; // Скрытие первой колонки, если нужно
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void account_Click(object sender, EventArgs e)
        {
            SaveDataToWord(dateTimePicker1.Value);
        }
        private void SaveDataToWord(DateTime selectedDate)
        {
            try
            {
                string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
                string query = "SELECT * FROM break_history WHERE time_ BETWEEN @startDate AND @endDate";

                // Создание таблицы для данных
                var dataTable = new System.Data.DataTable();

                // Получение данных за выбранный период
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("startDate", selectedDate);
                        command.Parameters.AddWithValue("endDate", DateTime.Now);

                        var dataAdapter = new NpgsqlDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных за выбранный период.");
                    return;
                }

                // Список пользовательских заголовков
                var customHeaders = new List<string>
        {
            "Идентификатор", // Для столбца id
            "Время",         // Для столбца time
            "Серия",         // Для столбца seria
            "Тип оборудования" // Для столбца machine_type
        };

                // Создание документа Word
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var document = wordApp.Documents.Add();

                var paragraph = document.Content.Paragraphs.Add();
                paragraph.Range.Text = $"Отчёт за период с {selectedDate.ToShortDateString()} по {DateTime.Now.ToShortDateString()}";
                paragraph.Range.InsertParagraphAfter();

                // Создание таблицы в Word
                Table wordTable = document.Tables.Add(paragraph.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);
                wordTable.Borders.Enable = 1;

                // Заполнение пользовательских заголовков таблицы
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    wordTable.Cell(1, i + 1).Range.Text = customHeaders[i];
                }

                // Заполнение строк таблицы
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        wordTable.Cell(i + 2, j + 1).Range.Text = dataTable.Rows[i][j]?.ToString() ?? "";
                    }
                }

                // Указание пути для сохранения
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Отчёты");
                Directory.CreateDirectory(folderPath); // Убедимся, что папка "Отчёты" существует
                string filePath = Path.Combine(folderPath, $"Отчёт_{selectedDate:yyyy-MM-dd}");

                document.SaveAs2(filePath);
                document.Close();
                wordApp.Quit();

                MessageBox.Show($"Отчёт сохранён: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}");
            }
        }
    }
}

