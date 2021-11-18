using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Laxanta19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            reg myForm = new reg();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string connStr = "server=192.168.4.211; user=student; database=usersleha; password=12345; ";
            string login, password;
            login = name.Text;
            password = passwords.Text;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string zap = "SELECT login,password FROM users WHERE login='" + login + "' AND password='" + password + "'";
            MySqlCommand command = new MySqlCommand(zap, conn);


            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (name.Text == "" || passwords.Text == "")
                {
                    MessageBox.Show("Введите логин и пароль");
                    MainWindow form1 = new MainWindow();
                }
                else
                {
                    MessageBox.Show("Вы вошли");
                    Window1 ss = new Window1();
                    ss.Show();
                    this.Hide();
                }
            }
            else
            {
                name.Text = "";
                passwords.Text = "";
                MessageBox.Show("Введен неверный логин или пароль");
            }


            conn.Close();
        }
    }
}
