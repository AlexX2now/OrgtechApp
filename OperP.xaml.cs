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
    /// Логика взаимодействия для OperP.xaml
    /// </summary>
    public partial class OperP : Window
    {
    TRmontEntities db = new TRmontEntities();
        private int usrid;
        public OperP(int userid)
        {
            InitializeComponent();
            usrid = userid;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void kolvo_Click(object sender, RoutedEventArgs e)
        {
            List<Заявка_> allz = db.Заявка_.ToList();
            MessageBox.Show("Всего заявок: " + allz.Count);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckZ cz = new CheckZ(usrid);
            cz.Show();
            this.Close();
        }

        private void addkl_Click(object sender, RoutedEventArgs e)
        {
            AddKl ak = new AddKl(usrid);
            ak.Show();
            this.Close();
        }
    }
}
