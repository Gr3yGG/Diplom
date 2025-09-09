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
    /// Interaction logic for Lists_Of_Fiction_Page.xaml
    /// </summary>
    public partial class Lists_Of_Fiction_Page : Page
    {
        public Lists_Of_Fiction_Page()
        {
            InitializeComponent();
            Update();

            Filt.Items.Add("Все категории");
            Filt.Items.Add("Пушкин А. С.");
            Filt.Items.Add("Лермонтов М. Ю.");
            Filt.Items.Add("Гоголь Н. В.");
            Filt.Items.Add("Островский А. Н.");
            Filt.Items.Add("Тургенев И. С.");
            Filt.Items.Add("Тютчев Ф. И.");
            Filt.SelectedIndex = 0;
        }
        private void Update()
        {
            IEnumerable<ListsOfFiction> listsoffictions = CoreModel.init().ListsOfFictions.Where(p => p.Author.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                listsoffictions = listsoffictions.Where(p => p.Author == Convert.ToString(Filt.SelectedItem));
            }

            DataGridLists_Of_Fiction.ItemsSource = listsoffictions.ToList();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Lists_Of_Fiction_Page(new ListsOfFiction()));
        }

        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLists_Of_Fiction.SelectedItems.Count > 1)
                return;
            ListsOfFiction ListsOfFictionDel = DataGridLists_Of_Fiction.SelectedItem as ListsOfFiction;

            if (MessageBox.Show("Удалить?", "Серьёзно удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().ListsOfFictions.Remove(ListsOfFictionDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            ListsOfFiction ListsOfFictionEdit = DataGridLists_Of_Fiction.SelectedItem as ListsOfFiction;
            NavigationService.Navigate(new Add_Lists_Of_Fiction_Page(ListsOfFictionEdit));
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
