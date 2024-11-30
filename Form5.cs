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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Data.SqlClient;


namespace опд1
{
    public partial class Form5 : Form
    {
        private Timer timer;
        public Form5()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10000; // 10 секунд
            timer.Tick += Timer_Tick; // Подписка на событие Tick
            timer.Start(); // Запуск таймера
        }
        string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
        private void Form5_Load(object sender, EventArgs e)
        {
            string[] status = new string[] { "Всё в порядке", "Требуется тех.осмотр", "Требуется обслуживание", "Требуется ремонт" };
            //string connectionString = "Host=localhost;Username=postgres;Password=98321;Database=opd";
            string query = "SELECT machine_type FROM equimpet WHERE fk_line_id = 1";
            string query2 = "SELECT machine_type FROM equimpet WHERE fk_line_id = 2";
            string query_weight_ub1 = "SELECT weight_untill_break FROM equimpet WHERE fk_line_id = 1";
            string query_scale1 = " SELECT weight_out FROM scales WHERE fk_line_id = 1";
            //string query2 = "SELECT machine_type FROM equimpet WHERE fk_line_id = 2";
            string query_equip = "SELECT * FROM equimpet";
            string query_probeg1 = "SELECT probeg FROM equimpet WHERE fk_line_id = 1";
            using (var connection = new NpgsqlConnection(connectionString))
            {

                connection.Open();

                var dataAdapter22 = new NpgsqlDataAdapter(query_equip, connection);
                var dataTable22 = new DataTable();


                //connection.Open();
                dataAdapter22.Fill(dataTable22);
                dataGridView1.DataSource = dataTable22;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 100; // Устанавливаем ширину каждого столбца в 100 пикселей
                }



                var dataAdapter = new NpgsqlDataAdapter(query, connection);
                var dataTable = new DataTable();


                //connection.Open();
                dataAdapter.Fill(dataTable);
                StringBuilder sb = new StringBuilder();


                var dataAdapter2 = new NpgsqlDataAdapter(query2, connection);
                var dataTable2 = new DataTable();


                //connection.Open();
                dataAdapter.Fill(dataTable2);
                StringBuilder sb2 = new StringBuilder();


                foreach (DataRow row in dataTable.Rows)
                {

                    sb.AppendLine(row["machine_type"].ToString());
                }

                foreach (DataRow row2 in dataTable2.Rows)
                {

                    sb2.AppendLine(row2["machine_type"].ToString());
                }
                //int i2 = 0;
                int i = 0;
                while (i<100)
                { 
                    textBox1.Text += sb[i].ToString();

                    if (sb[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                
                while (i < 100)
                {
                    textBox2.Text += sb[i].ToString();

                    if (sb[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                while (i < 100)
                {
                    textBox3.Text += sb[i].ToString();

                    if (sb[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                while (i < 100)
                {
                    textBox4.Text += sb[i].ToString();
                    if (sb[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }

                //*********************************************************************
                i = 0;
                while (i < 100)
                {
                    first_eq.Text += sb2[i].ToString();

                    if (sb2[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }

                while (i < 100)
                {
                    second_eq.Text += sb2[i].ToString();

                    if (sb2[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                while (i < 100)
                {
                    third_eq.Text += sb2[i].ToString();

                    if (sb2[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                while (i < 100)
                {
                    four_eq.Text += sb2[i].ToString();
                    if (sb2[i] == '\r')
                    {
                        i += 1;
                        break;
                    }
                    else
                        i++;
                }
                //************************************************************* СОБИРАЕМ МАССИВ В КОТОРОМ БУДУТ КРИТИЧЕСКИЕ ВЕСА ОБОРУДОВАНИЯ
                var dataAdapter3 = new NpgsqlDataAdapter(query_weight_ub1, connection);
                var dataTable3 = new DataTable();


                //connection.Open();
                dataAdapter3.Fill(dataTable3);
                StringBuilder sb3 = new StringBuilder();
                int[] numbers = new int[4];
                string wub = string.Empty;

                int ii = 0;
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    wub = row3["weight_untill_break"].ToString();
                    numbers[ii]=int.Parse(wub);
                    //sb3.AppendLine(row3["weight_untill_break"].ToString());
                    ii++;
                }
                //textBox5.Text = numbers.ToString();
                //****************************************************************** СОБИРАЮ ДАННЫЙ О ПРОБЕГЕ
                var dataAdapter1 = new NpgsqlDataAdapter(query_probeg1, connection);
                var dataTable1 = new DataTable();


                //connection.Open();
                dataAdapter1.Fill(dataTable1);
                StringBuilder sb1 = new StringBuilder();
                int[] numbers1 = new int[4];
                string wub1 = string.Empty;

                int ii1 = 0;
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    wub1 = row1["probeg"].ToString();
                    numbers1[ii1] = int.Parse(wub1);
                    //sb3.AppendLine(row3["weight_untill_break"].ToString());
                    ii1++;
                }
                //****************************************************************** СОБИРАЮ СТРОКУ С ТИПАМИ ОБОРУДОВАНИЯ
                var dataAdapter33 = new NpgsqlDataAdapter(query, connection);
                var dataTable33 = new DataTable();


                //connection.Open();
                dataAdapter33.Fill(dataTable3);
               
              
                string maty = string.Empty;

                
                foreach (DataRow row3 in dataTable3.Rows)
                {
                    maty += row3["machine_type"].ToString();
                }

                //****************************************************************** ВЫСЧИТЫВАЕМ СУММУ ВЕСА

                var dataAdapter4 = new NpgsqlDataAdapter(query_scale1, connection);
                var dataTable4 = new DataTable();


                //connection.Open();
                dataAdapter4.Fill(dataTable4);
                //List<string> weights = new List<string>();
                string result = string.Empty;
                int weight_outSum=0;
                foreach (DataRow row4 in dataTable4.Rows)
                {
                    result =row4["weight_out"].ToString();
                    weight_outSum += int.Parse(result);
                }
               // string result = string.Join(Environment.NewLine, weights);
                string WOS = weight_outSum.ToString();
                //textBox5.Text = WOS;
                // Сначала я получаю, занчения из пробега в массив, затем прибовляю к ним новый вес, затем вписываю обратно
                //var dataAdapterpro = new NpgsqlDataAdapter(query_probeg1, connection);
                //var dataTablepro = new DataTable();


                ////connection.Open();
                //dataAdapterpro.Fill(dataTablepro);
                //StringBuilder sbpro = new StringBuilder();
                //int[] numberspro = new int[4];
                //string wubpro = string.Empty;

                //int iipro = 0;
                
               
                //foreach (DataRow rowpro in dataTablepro.Rows)
                //{
                //    wub = rowpro["probeg"].ToString();
                //    numbers[iipro] = int.Parse(wub);
                //    //sb3.AppendLine(row3["weight_untill_break"].ToString());
                //    iipro++;

                //}

                //*************************************************************************СРАВНИВАЕМ ВЫШЕДШИЙ ВЕС С КРИТИЧЕСКИМ
                for (int iq=0; iq < 4; iq++)
                {
                    if ((numbers1[iq] * 100 / numbers[iq])<150 && (numbers1[iq] * 100 / numbers[iq])>100)//Вычисляем какой технике требуется проверка
                    {
                        string querymas = "SELECT seria, machine_type FROM equimpet WHERE fk_line_id=1 AND weight_untill_break= @numbersIQ";
                        using (var connection2 = new NpgsqlConnection(connectionString))
                        {
                            using (var command = new NpgsqlCommand(querymas, connection2)) // Исправлено: используем connection2
                            {
                                command.Parameters.AddWithValue("numbersIQ", numbers[iq]); // Убедитесь, что параметр не начинается с '@'

                                connection2.Open(); // Исправлено: используем connection2

                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        // Получаем значения seria и machine_type
                                        string seria = reader.GetString(0); // Получаем значение seria
                                        string machineType = reader.GetString(1); // Получаем значение machine_type

                                        // Формируем строку с данными
                                        string resultt = $"Seria: {seria}, Machine Type: {machineType}";
                                        //MessageBox.Show(resultt, "Требуется проверка на первой линии");
                                        textBox5.Text += "Требуется проверка на первой линии: " + resultt+"\n\n";
                                        textBox5.Text += Environment.NewLine;
                                        // Выводим результат
                                        //Console.WriteLine(result);
                                    }
                                }
                            }
                        }

                        
                    }

                    if ((numbers1[iq] * 100 / numbers[iq]) > 150)// вычисляем кокой технике требуется обслуживание
                    {
                        string querymas = "SELECT seria, machine_type FROM equimpet WHERE fk_line_id=1 AND weight_untill_break= @numbersIQ";
                        using (var connection2 = new NpgsqlConnection(connectionString))
                        {
                            using (var command = new NpgsqlCommand(querymas, connection2)) // Исправлено: используем connection2
                            {
                                command.Parameters.AddWithValue("numbersIQ", numbers[iq]); // Убедитесь, что параметр не начинается с '@'

                                connection2.Open(); // Исправлено: используем connection2

                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        // Получаем значения seria и machine_type
                                        string seria = reader.GetString(0); // Получаем значение seria
                                        string machineType = reader.GetString(1); // Получаем значение machine_type

                                        // Формируем строку с данными
                                        string resultt = $"Seria: {seria}, Machine Type: {machineType}";
                                        textBox5.Text += "Требуется обслуживание на первой линии: " + (resultt + "\n\n");
                                        textBox5.Text += Environment.NewLine;

                                        // MessageBox.Show(resultt, "Требуется обслуживание на первой линии");
                                        // Выводим результат
                                        //Console.WriteLine(result);
                                    }
                                }
                            }
                        }

                    }
                }
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
           // Form1 f1 = new Form1();
           this.Close();
            //f1.Show();
        }
        

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновляем данные в DataGridView
            LoadData();
        }
        private void LoadData()
        {
            string querySelect = "SELECT * FROM equimpet";
            using (var connection44 = new NpgsqlConnection(connectionString))
            {
                connection44.Open();

                using (var command = new NpgsqlCommand(querySelect, connection44))
                {
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable; // Обновляем источник данных для DataGridView
                    }
                }
            }
        }
        string seria ;
        string machineType;
        private void button1_Click(object sender, EventArgs e)
        {
            
            string repid = textBox6.Text;
            int idrep = int.Parse(repid);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string queryInprob = "UPDATE equimpet SET probeg = @probeg WHERE id = @idrep";
                
                string queryser = $"SELECT seria, machine_type FROM equimpet WHERE id = {idrep}";

                using (var command = new NpgsqlCommand(queryInprob, connection))
                {
                    
                    command.Parameters.AddWithValue("@probeg", NpgsqlTypes.NpgsqlDbType.Integer, 1);
                    command.Parameters.AddWithValue("@idrep", NpgsqlTypes.NpgsqlDbType.Integer, idrep);




                    try
                    {
                        //connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} запись(и) о ремонте добавлена(ы).");
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
                //******************************************************Вводим данные в историю поломок
                using (var connectioneq = new NpgsqlConnection(connectionString))// забираем данные из equimpet
                {
                    connectioneq.Open();

                    using (var command = new NpgsqlCommand(queryser, connectioneq))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            // Проверяем, есть ли строки в результате
                            if (reader.Read())
                            {
                                // Извлекаем значения из результата
                                seria = reader["seria"].ToString();
                                machineType = reader["machine_type"].ToString();

                                // Выводим значения
                                
                            }
                            else
                            {
                                Console.WriteLine("Нет записей с заданным id.");
                            }
                        }
                    }
                }
                string queryInHist = "INSERT INTO break_history (time_, seria,machine_type) VALUES (@time_,@seria,@type)";
                using (var command = new NpgsqlCommand(queryInHist, connection))
                {
                    DateTime currentDateTime = DateTime.Now;

                    command.Parameters.AddWithValue("@time_", NpgsqlTypes.NpgsqlDbType.Timestamp, currentDateTime);
                    command.Parameters.AddWithValue("@seria", NpgsqlTypes.NpgsqlDbType.Text, seria);
                    command.Parameters.AddWithValue("@type", NpgsqlTypes.NpgsqlDbType.Text, machineType);

                    command.ExecuteNonQuery();
                }



            }










        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
