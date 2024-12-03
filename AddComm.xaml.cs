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
    /// Логика взаимодействия для AddComm.xaml
    /// </summary>
    public partial class AddComm : Window
    {
        private int urid;
        TRmontEntities db = new TRmontEntities();
        public AddComm(int userid)
        {
            InitializeComponent();
            urid = userid;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MasterP ms = new MasterP(urid);
            ms.Show();
            this.Close();
        }
    }
}
