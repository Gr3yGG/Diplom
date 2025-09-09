using Diplom.Windows;
using MySqlConnector;
using Diplom.BdModels;
using Diplom.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Unicode;
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

namespace Diplom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == "" || PasswordBB.Password == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                User user = CoreModel.init().Users.FirstOrDefault(p => p.Login == LoginTB.Text &&
                (p.Password == PasswordBB.Password));

                if (user != null)
                {
                    MessageBox.Show("Добро пожаловать!");
                    Window_Menu wind = new Window_Menu();
                    wind.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Всё неправильно");
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Autor_Click1(object sender, RoutedEventArgs e)
        {
            Registration wind = new Registration(new User());
            wind.Show();
        }
    }
}
