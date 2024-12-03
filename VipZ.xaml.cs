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
    /// Логика взаимодействия для VipZ.xaml
    /// </summary>
    public partial class VipZ : Window
    {
        private int urid;
        TRmontEntities db = new TRmontEntities();
        public VipZ(int userid)
        {
            InitializeComponent();
            urid = userid;

            List<Заявка_> allz = db.Заявка_.Where(x=>x.Код_мастера == null).ToList();
            for (int i = 0; i < allz.Count; i++)
            {
                neededz.Items.Add(allz[i].Оргтехника_ + " - " + allz[i].Проблемы.Описание_проблемы);
            }

            List<C_Статус_заявки__> allst = db.C_Статус_заявки__.ToList();
            for (int i = 0; i < allst.Count; i++)
            {
                newstat.Items.Add(allst[i].Наименование);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MasterP ms = new MasterP(urid);
            ms.Show();
            this.Close();
        }

        private void neededz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Заявка_> allz = db.Заявка_.Where(x => x.Код_мастера == null).ToList();
            stattext.Text = allz[neededz.SelectedIndex].C_Статус_заявки__.Наименование;
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (neededz.SelectedIndex == -1 || newstat.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите заявку и ее новый статус");
            }
            else
            {
                List<Заявка_> allz = db.Заявка_.Where(x => x.Код_мастера == null).ToList();

                if (newstat.Text == allz[neededz.SelectedIndex].C_Статус_заявки__.Наименование)
                {
                    MessageBox.Show("Выберите другой статус");
                }
                else
                {
                    allz[neededz.SelectedIndex].Код_статуса_заявки = newstat.SelectedIndex + 1;
                    allz[neededz.SelectedIndex].Код_мастера = urid;
                    db.SaveChanges();

                    MessageBox.Show("Статус успешно изменен");
                }

            }
        }
    }
}
