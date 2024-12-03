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
    /// Логика взаимодействия для MasterP.xaml
    /// </summary>
    public partial class MasterP : Window
    {
    TRmontEntities db = new TRmontEntities();
        private int urid;
        public MasterP(int masid)
        {
            InitializeComponent();
            urid = masid;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void checkz_Click(object sender, RoutedEventArgs e)
        {
            CheckZ cz = new CheckZ(urid);
            cz.Show();
            this.Close();
        }

        private void vipbtn_Click(object sender, RoutedEventArgs e)
        {
            VipZ vz = new VipZ(urid);
            vz.Show();
            this.Close();
        }

        private void addcomm_Click(object sender, RoutedEventArgs e)
        {
            AddComm ac = new AddComm(urid);
            ac.Show();
            this.Close();
        }

        private void zakdet_Click(object sender, RoutedEventArgs e)
        {
            ZakDet zd = new ZakDet(urid);
            zd.Show();
            this.Close();
        }
    }
}
