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
    /// Interaction logic for Lists_Of_Textbook_Page.xaml
    /// </summary>
    public partial class Lists_Of_Textbook_Page : Page
    {
        public Lists_Of_Textbook_Page()
        {
            InitializeComponent();
            Update();

            Filt.Items.Add("Все категории");
            Filt.Items.Add("Азбука");
            Filt.Items.Add("Учебник для детей");
            Filt.Items.Add("Русский язык. Азбука 1 й класс");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.SelectedIndex = 0;
        }
        private void Update()
        {
            IEnumerable<ListsOfTextbook> listsoftextbooks = CoreModel.init().ListsOfTextbooks.Where(p => p.Name.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                listsoftextbooks = listsoftextbooks.Where(p => p.Name == Convert.ToString(Filt.SelectedItem));
            }

            DataGridLists_Of_Textbook.ItemsSource = listsoftextbooks.ToList();
        }


        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLists_Of_Textbook.SelectedItems.Count > 1)
                return;
            ListsOfTextbook ListsOfTextbookDel = DataGridLists_Of_Textbook.SelectedItem as ListsOfTextbook;

            if (MessageBox.Show("Удалить?", "Серьёзно удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().ListsOfTextbooks.Remove(ListsOfTextbookDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Lists_Of_Textbook_Page(new ListsOfTextbook()));
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            ListsOfTextbook ListsOfTextbookEdit = DataGridLists_Of_Textbook.SelectedItems as ListsOfTextbook;
            NavigationService.Navigate(new Add_Lists_Of_Textbook_Page(ListsOfTextbookEdit));
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
