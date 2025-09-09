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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom.Pages
{
    /// <summary>
    /// Interaction logic for User_Page.xaml
    /// </summary>
    public partial class User_Page : Page
    {
        public User_Page()
        {
            InitializeComponent();
            Update();

            Filt.Items.Add("Все категории");
            Filt.Items.Add("Иванов");
            Filt.Items.Add("Сергеев");
            Filt.Items.Add("Артёмов");
            Filt.Items.Add("Михайлов");
            Filt.Items.Add("Александров");
            Filt.Items.Add("Пётров");
            Filt.SelectedIndex = 0;
        }
        private void Update()
        {
            IEnumerable<User> users = CoreModel.init().Users.Where(p => p.Surname.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                users = users.Where(p => p.Surname == Convert.ToString(Filt.SelectedItem));
            }

            DataGridUser.ItemsSource = users.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_User_Page(new User()));
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();

        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            User UserEdit = DataGridUser.SelectedItem as User;
            NavigationService.Navigate(new Add_User_Page(UserEdit));
        }

        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUser.SelectedItems.Count > 1)
                return;
            User UserDel = DataGridUser.SelectedItem as User;

            if (MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Users.Remove(UserDel);
                CoreModel.init().SaveChanges();

                Update();
            }
        }

        private void SearchChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FiltChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
