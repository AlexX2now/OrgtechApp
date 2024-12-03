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
    /// Логика взаимодействия для CheckZ.xaml
    /// </summary>
    public partial class CheckZ : Window
    {
        TRmontEntities db = new TRmontEntities();
        private int usrid;
        public CheckZ(int userid)
        {
            InitializeComponent();
            usrid= userid;

            List<Оргтехника_> allorgt = db.Оргтехника_.ToList();
            for (int i = 0; i < allorgt.Count; i++) {
            masterlist.Items.Add(allorgt[i].Название);
            }

            var user = db.Пользователи_.FirstOrDefault(x=>x.Код == userid);
            string date;

            switch (user.Код_должности){
                case 4:
                    //заказчик
                    List<Заявка_> klientzayavlist = db.Заявка_.Where(x=>x.Код_клиента == user.Код).ToList();
                    List<Zayavki> toshow = new List<Zayavki>();
                    for (int i = 0; i < klientzayavlist.Count; i++){

                    if (klientzayavlist[i].Дата_конца == null){
                            date = "-";
                    }
                    else{
                            date = klientzayavlist[i].Дата_конца.Value.ToShortDateString();
                    }

                    toshow.Add(new Zayavki(klientzayavlist[i].Дата_начала.Value.ToShortDateString(),
                        klientzayavlist[i].Оргтехника_.Название, klientzayavlist[i].Модели_.Модель,
                        klientzayavlist[i].Проблемы.Описание_проблемы,
                        klientzayavlist[i].C_Статус_заявки__.Наименование,date
                        )) ;
                    }
                    zayvlist.ItemsSource = toshow;
                    break;
                default:
                    //все другое
                    List<Заявка_> allzauav = db.Заявка_.ToList();
                    List<Zayavki> toshowa = new List<Zayavki>();
                    for (int i = 0; i < allzauav.Count; i++)
                    {
                        if (allzauav[i].Дата_конца == null)
                        {
                            date = "-";
                        }
                        else
                        {
                            date = allzauav[i].Дата_конца.Value.ToShortDateString();
                        }


                        toshowa.Add(new Zayavki(allzauav[i].Дата_начала.Value.ToShortDateString(),
                            allzauav[i].Оргтехника_.Название, allzauav[i].Модели_.Модель,
                            allzauav[i].Проблемы.Описание_проблемы,
                            allzauav[i].C_Статус_заявки__.Наименование,
                            date));
                    }
                    zayvlist.ItemsSource = toshowa;
                    break;
            }
        }

        public class Zayavki
        {
            public string StartDate { get; set; }
            public string Orgtech { get; set; }
            public string Model { get; set; }
            public string Problem { get; set; }
            public string Status { get; set; }
            public string EndDate { get; set; }
            public Zayavki(string startdate, string orgtech, string model, string problem, string status, string enddate) {
            StartDate= startdate;
            Orgtech= orgtech;
            Model= model;
            Problem= problem;
            Status= status; 
            EndDate= enddate;
            }
        }

        private void filtr_Click(object sender, RoutedEventArgs e)
        {
        if (masterlist.SelectedIndex == -1){
                MessageBox.Show("Выбеите оргтехнику, что бы посмотреть заявки");
        }
        else{
                //Фильтр по оргтехнике
                zayvlist.ItemsSource = null;
                string date;

                var user = db.Пользователи_.FirstOrDefault(x=>x.Код == usrid);

                if (user.Код_должности == 4){
                    List<Заявка_> filtrz = db.Заявка_.Where(x => x.Код_оргтехники == masterlist.SelectedIndex + 1 && x.Код_клиента == usrid).ToList();
                    List<Zayavki> toshowa = new List<Zayavki>();
                    for (int i = 0; i < filtrz.Count; i++)
                    {
                        if (filtrz[i].Дата_конца == null)
                        {
                            date = "-";
                        }
                        else
                        {
                            date = filtrz[i].Дата_конца.Value.ToShortDateString();
                        }

                        toshowa.Add(new Zayavki(filtrz[i].Дата_начала.Value.ToShortDateString(),
                            filtrz[i].Оргтехника_.Название, filtrz[i].Модели_.Модель,
                            filtrz[i].Проблемы.Описание_проблемы,
                            filtrz[i].C_Статус_заявки__.Наименование, date));
                    }
                    zayvlist.ItemsSource = toshowa;
                }
                else{
                    List<Заявка_> filtrz = db.Заявка_.Where(x => x.Код_оргтехники == masterlist.SelectedIndex + 1).ToList();
                    List<Zayavki> toshowa = new List<Zayavki>();
                    for (int i = 0; i < filtrz.Count; i++)
                    {
                        if (filtrz[i].Дата_конца == null)
                        {
                            date = "-";
                        }
                        else
                        {
                            date = filtrz[i].Дата_конца.Value.ToShortDateString();
                        }

                        toshowa.Add(new Zayavki(filtrz[i].Дата_начала.Value.ToShortDateString(),
                            filtrz[i].Оргтехника_.Название, filtrz[i].Модели_.Модель,
                            filtrz[i].Проблемы.Описание_проблемы,
                            filtrz[i].C_Статус_заявки__.Наименование, date));
                    }
                    zayvlist.ItemsSource = toshowa;
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Пользователи_.FirstOrDefault(x=>x.Код == usrid);

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
