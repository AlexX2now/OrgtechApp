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
    /// Логика взаимодействия для MakeZayav.xaml
    /// </summary>
    public partial class MakeZayav : Window
    {
    TRmontEntities db = new TRmontEntities();
        private int ursid;
        public MakeZayav(int userid)
        {
            InitializeComponent();

            ursid= userid;
            List<Оргтехника_> allorg = db.Оргтехника_.ToList();
            List<Проблемы> allprob = db.Проблемы.ToList();
            
            for (int i = 0; i < allorg.Count; i++){
                orgtec.Items.Add(allorg[i].Название);
            }
            for (int i = 0; i < allprob.Count; i++){
                problem.Items.Add(allprob[i].Описание_проблемы);
            }
        }

        private void createz_Click(object sender, RoutedEventArgs e)
        {
        try{
                if (string.IsNullOrEmpty(model.Text)
                    || orgtec.SelectedIndex == -1
                    || problem.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    List<Модели_> allmodels = db.Модели_.ToList();
                    using (var context = new TRmontEntities())
                    {
                        var newmodel = new Модели_
                        {
                            Модель = model.Text
                        };
                        context.Модели_.Add(newmodel);
                        context.SaveChanges();

                        var newz = new Заявка_
                        {
                            Дата_начала = DateTime.Now,
                            Код_оргтехники = orgtec.SelectedIndex + 1,
                            Код_проблемы = problem.SelectedIndex + 1,
                            Код_модели = allmodels.Count + 1,
                            Код_статуса_заявки = 3,
                            Код_клиента = ursid
                        };
                        context.Заявка_.Add(newz);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Заявка успешно создана!");
                }
            }
        catch{
                MessageBox.Show("Что-то пошло не так");
        }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            KlientP kp = new KlientP(ursid);
            kp.Show();
            this.Close();
        }
    }
}
