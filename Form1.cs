using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

//Я сломал репозиторий//Я сломал репозиторий//Я сломал репозиторий

namespace опд1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




    private void logon_Click(object sender, EventArgs e)
        {
            int k = 0;
            bool admin = false;

            if (login.Text == "admin")

            {

                if (password.Text == "admin")

                {

                    //Form2 f2 = new Form2();

                    //f2.Show();
                    Form5 f5 = new Form5();
                    f5.Show();
                    k = 1;
                    admin = true;
                   // this.Hide();
                }

            }

            if (login.Text == "buhg")

            {

                if (password.Text == "buhg")

                {

                    Form2 f2 = new Form2();

                    f2.Show();
                    k = 1;
                   // this.Hide();
                }

            }

            if (login.Text == "dir")

            {

                if (password.Text == "dir")

                {

                    Form3 f3 = new Form3();

                    f3.Show();
                    k = 1;
                    admin = true;
                   // this.Hide();
                }

            }

            if (login.Text == "employ")

            {

                if (password.Text == "employ")

                {

                    Form4 f4 = new Form4();

                    f4.Show();
                    k=1;
                   // this.Hide();
                }

            }

            if (k == 0)
            {
                MessageBox.Show(" Неверный логин или пароль");
            }



            
        }
    }
}
