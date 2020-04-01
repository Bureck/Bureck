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

namespace Bureck___The_Game
{
    /// <summary>
    /// Logika interakcji dla klasy Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void getdark(object sender, MouseEventArgs e)
        {
            guzik_start.Source = zklikiem.Source;
        }

        private void getback(object sender, MouseEventArgs e)
        {
            guzik_start.Source = bezkliku.Source;
        }

        private void start(object sender, MouseButtonEventArgs e)
        {
            MainWindow gra = new MainWindow();
            gra.Show();
            this.Close();
        }
    }
}
