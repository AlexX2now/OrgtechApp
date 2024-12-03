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

namespace UP_2
{
    /// <summary>
    /// Логика взаимодействия для KlientP.xaml
    /// </summary>
    public partial class KlientP : Window
    {
        private int userid;
        public KlientP(int kid)
        {
            InitializeComponent();
            userid= kid;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void toz_Click(object sender, RoutedEventArgs e)
        {
            CheckZ cz = new CheckZ(userid);
            cz.Show();
            this.Close();
        }

        private void createzayav_Click(object sender, RoutedEventArgs e)
        {
            MakeZayav mz = new MakeZayav(userid);
            mz.Show();
            this.Close();
        }

        private void redzayav_Click(object sender, RoutedEventArgs e)
        {
        RedZayav rz = new RedZayav(userid);
        rz.Show();
        this.Close();
        }
    }
}
