using Diplom.BdModels;
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

namespace Diplom.Windows
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        User user;
        public Registration(User doc)
        {
            this.user = doc;
            DataContext = user;

            InitializeComponent();
        }

        private void Border_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Autor_Click2(object sender, RoutedEventArgs e)
        {
            if (SurnameTB.Text == "" || NameTB.Text == "" || PatronymicTB.Text == "" || LoginTB1.Text == "" || PasswordBB1.Text == "" || DolzhnostTB.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                CoreModel.init().Users.Add(user);
                CoreModel.init().SaveChanges();
                this.Close();

                if (user != null)
                {
                    MessageBox.Show("Пользователь зарегестрирован!");
                }
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
