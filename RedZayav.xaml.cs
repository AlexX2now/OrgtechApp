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
    /// Логика взаимодействия для RedZayav.xaml
    /// </summary>
    public partial class RedZayav : Window
    {
    TRmontEntities db = new TRmontEntities();
        private int ursid;
        public RedZayav(int userid)
        {
            InitializeComponent();

            List<Заявка_> allzayavuser = db.Заявка_.Where(x=>x.Код_клиента == userid && x.Код_статуса_заявки == 3).ToList();

            for (int i = 0; i < allzayavuser.Count; i++){
                neededz.Items.Add(allzayavuser[i].Оргтехника_.Название + " - " + 
                allzayavuser[i].Проблемы.Описание_проблемы);
            }

            ursid = userid;
            List<Оргтехника_> allorg = db.Оргтехника_.ToList();
            List<Проблемы> allprob = db.Проблемы.ToList();

            for (int i = 0; i < allorg.Count; i++)
            {
                orgtec.Items.Add(allorg[i].Название);
            }
            for (int i = 0; i < allprob.Count; i++)
            {
                problem.Items.Add(allprob[i].Описание_проблемы);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            KlientP kp = new KlientP(ursid);
            kp.Show();
            this.Close();
        }

        private void createz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Text)
                    || orgtec.SelectedIndex == -1
                    || problem.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    List<Заявка_> users = db.Заявка_.Where(x => x.Код_клиента == ursid).ToList();
                    users[neededz.SelectedIndex].Модели_.Модель = model.Text;
                    users[neededz.SelectedIndex].Код_проблемы = problem.SelectedIndex + 1;
                    users[neededz.SelectedIndex].Код_оргтехники = orgtec.SelectedIndex + 1;
                    db.SaveChanges();
                    MessageBox.Show("Заявка успешно отредактирована");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void neededz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Заявка_> users = db.Заявка_.Where(x => x.Код_клиента == ursid).ToList();
            model.Text = users[neededz.SelectedIndex].Модели_.Модель;
            orgtec.SelectedIndex = users[neededz.SelectedIndex].Код_оргтехники.Value - 1;
            problem.SelectedIndex = users[neededz.SelectedIndex].Код_проблемы.Value - 1;
        }
    }
}
