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
using System.Windows.Threading;

namespace YP_session_one.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto 
    {
        WindowsKod windowsKod = new WindowsKod();
        public int kk2 = 0;
        private int timer = 10;
        public int kk;
        public int v;
        public int v2;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string kod;
        string kod1;
        bool ss = false;

        public PageAuto()
        {
            InitializeComponent();
        }

        public PageAuto(int kk, string kod)
        {
            InitializeComponent();
            if (kk != 0)
            {
                Kod.IsEnabled = true;
                Password.IsEnabled = false;
                Number.IsEnabled = false;

                Kod.Focus();

                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Backk);
                dispatcherTimer.Start();
                kk2 = kk;
                kod1 = kod;
                v2 = v;
            }
        }


        public PageAuto(int kk, string kod, int v)
        {
            InitializeComponent();
            if (kk != 0)
            {
                Kod.IsEnabled = true;
                Password.IsEnabled = false;
                Number.IsEnabled = false;

                Kod.Focus();

                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Backk);
                dispatcherTimer.Start();
                kk2 = kk;
                kod1 = kod;
                v2 = v;
                v2++;
            }
        }


        private void Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string num = Number.Text;
                Employee employees = ClassBase.BD.Employee.FirstOrDefault(x => x.Number == num);

                if (employees != null)
                {
                    Password.IsEnabled = true;
                    Number.IsEnabled = false;
                    Password.Focus();
                }
                else
                {
                    MessageBox.Show("Данного сотрудника нет в базе", "Сообщение");
                }
            }
        }

        private void Backk(object sender, EventArgs e)
        {
            if (timer == -1)
            {
                dispatcherTimer.Stop();
                TextClue.Text = "Вы не успели ввести код\nДля повторной отправки кода нажмите кнопку";
                Kod.IsEnabled = false;
                Password.IsEnabled = false;
                Number.IsEnabled = false;
                Kod.Text = "";
                img.IsEnabled = true;
                Entry.IsEnabled = false;

            }
            else
            {
                TextClue.Text = "Таймер: " + timer;
                Entry.IsEnabled = true;
            }
            timer--;
        }
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string pass = Password.Text;
                Employee employees = ClassBase.BD.Employee.FirstOrDefault(x => x.Password == pass);

                if (employees != null)
                {
                    windowsKod.ShowDialog();
                    kk = employees.Role;
                    kod = windowsKod.text;

                   ClassFrame.lframe.Navigate(new PageAuto(kk, kod));
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Tick += new EventHandler(Backk);
                    dispatcherTimer.Start();
                }
                else
                {
                    MessageBox.Show("Пароль введен неверно", "Сообщение");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Number.Clear();
            Password.Clear();
            Kod.Clear();
            Kod.IsEnabled = false;
            Password.IsEnabled = false;
            Number.IsEnabled = true;
            img.IsEnabled = false;
            dispatcherTimer.Stop();
            TextClue.Text = "";
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            Role roles = ClassBase.BD.Role.FirstOrDefault(x => x.Role_ID == kk2);
            if (Kod.Text == kod1)
            {
                MessageBox.Show($"Поздравляю вы авторизировались!\nВаша роль {roles.Role1}", "Сообщение");
                Kod.IsEnabled = false;
                Password.IsEnabled = false;
                Number.IsEnabled = false;
                img.IsEnabled = false;
                dispatcherTimer.Stop();
                TextClue.Text = "";
                Kod.Text = "";
            }
            else
            {
                Password.IsEnabled = false;
                Number.IsEnabled = false;
                MessageBox.Show("Неверный код", "Сообщение");
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (v2 != 1)
            {
                WindowsKod windowKod = new WindowsKod();
                windowKod.ShowDialog();
                v = windowKod.v;
                //kk = employees.id_role;
                kod = windowKod.text;
                ClassFrame.lframe.Navigate(new PageAuto(kk2, kod, v2));

                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Backk);
                dispatcherTimer.Start();
            }
            else
            {//uyv=X)%k
                MessageBox.Show("Закончились попытки", "Сообщение");
                Kod.IsEnabled = false;

                Back.IsEnabled = false;
                Entry.IsEnabled = false;
            }
        }

        private void Kod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Role roles = ClassBase.BD.Role.FirstOrDefault(x => x.Role_ID == kk2);
                //MessageBox.Show($"{kod1}", "Сообщение");
                if (Kod.Text == kod1)
                {
                    MessageBox.Show($"Поздравляю вы авторизировались!\nВаша роль {roles.Role1}", "Сообщение");
                    Kod.IsEnabled = false;
                    Password.IsEnabled = false;
                    Number.IsEnabled = false;
                    Back.IsEnabled = false;
                    Entry.IsEnabled = false;
                    img.IsEnabled = false;
                    dispatcherTimer.Stop();
                    TextClue.Text = "";
                    Kod.Text = "";
                }
                else
                {
                    Password.IsEnabled = false;
                    Number.IsEnabled = false;
                    Entry.IsEnabled = false;
                    MessageBox.Show("Неверный код", "Сообщение");
                }
            }
        }
    }
}
