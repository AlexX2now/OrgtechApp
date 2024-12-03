using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для AddKl.xaml
    /// </summary>
    public partial class AddKl : Window
    {
        private int urid;
        TRmontEntities db = new TRmontEntities();
        public AddKl(int userid)
        {
            InitializeComponent();
            urid = userid;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            OperP op = new OperP(urid);
            op.Show();
            this.Close();
        }

        private void addklbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(surname.Text) ||
                string.IsNullOrEmpty(name.Text) ||
                string.IsNullOrEmpty(trim.Text) ||
                string.IsNullOrEmpty(phone.Text) ||
                string.IsNullOrEmpty(login.Text) ||
                string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Не оставляйте поля пустыми");
            }
            else
            {
                if (phone.Text.Length != 11 || int.TryParse(phone.Text, out _))
                {
                    MessageBox.Show("Введите корректный номер телефона");
                }
                else{
                    using (var context = new TRmontEntities())
                    {
                        var newkl = new Пользователи_
                        {
                            Фамилия = surname.Text,
                            Имя = name.Text,
                            Отчество = trim.Text,
                            Телефон = phone.Text,
                            Логин = login.Text,
                            Пароль = password.Text,
                            Код_должности = 4
                        };
                        context.Пользователи_.Add(newkl);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Клиент успешно добавлен!ы");
                }
            }
        }
    }
}
