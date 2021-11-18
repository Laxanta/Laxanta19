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
using MySql.Data.MySqlClient;
using System.Data;
namespace Laxanta19
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            string connStr = "server=192.168.4.211; user=student; database=bespalov431; password=12345; ";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `izdeliya` WHERE 1", conn);
            ad.SelectCommand = com;

            DataTable dt = new DataTable();
            ad.Fill(dt);
            GdGrid.ItemsSource = dt.DefaultView;
        }

        private void GdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
