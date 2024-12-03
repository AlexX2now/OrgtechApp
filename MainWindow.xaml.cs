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

namespace UP_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TRmontEntities db = new TRmontEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void authbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text)){
                MessageBox.Show("Не оставляйте логин пустым");
            }
            else{
                var user = db.Пользователи_.FirstOrDefault(x=>x.Логин == login.Text && x.Пароль == password.Text);

                if (user == null){
                    MessageBox.Show("Такого пользователя нет");
                }
                else{
                switch (user.Код_должности){
                        case 1:
                            //менеджер
                            ManagerP mp = new ManagerP();
                            mp.Show();
                            this.Close();
                            break;
                        case 2:
                            //мастер
                            MasterP map = new MasterP(user.Код);
                            map.Show();
                            this.Close();
                            break;
                        case 3:
                            //оператор
                            OperP op = new OperP(user.Код);
                            op.Show();
                            this.Close();
                            break;
                        case 4:
                            //заказчик
                            KlientP kp = new KlientP(user.Код);
                            kp.Show();
                            this.Close();
                            break;
                }
                }
            }
        }
    }
}
