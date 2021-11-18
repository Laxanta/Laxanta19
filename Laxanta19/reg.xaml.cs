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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Laxanta19
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow myForm = new MainWindow();
            this.Hide();
            myForm.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string conStr = "server=192.168.4.211; user=student; database=usersleha; password=12345; charset=utf8;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string fio_pos, log_pol, pas_pol, rol_pos;

                    fio_pos = textBox4.Text;
                    log_pol = textBox1.Text;
                    pas_pol = textBox2.Text;
                    rol_pos = textBox3.Text;

                    string sql = "INSERT INTO users (login, password, rul, fio)" +
                   "VALUES (@login, @password, @rul, @fio);";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметры и добавляем их в коллекцию




                    cmd.Parameters.AddWithValue("@fio", fio_pos);
                    cmd.Parameters.AddWithValue("@login", log_pol);
                    cmd.Parameters.AddWithValue("@password", pas_pol);
                    cmd.Parameters.AddWithValue("@rul", rol_pos);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Вы зарегистрировались");
                    MainWindow myForm = new MainWindow();
                    this.Hide();
                    myForm.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
