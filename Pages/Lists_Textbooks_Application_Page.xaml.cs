using Diplom.BdModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for Lists_Textbooks_Application_Page.xaml
    /// </summary>
    public partial class Lists_Textbooks_Application_Page : Page
    {
        public Lists_Textbooks_Application_Page()
        {
            InitializeComponent();
            Update();

            Filt.Items.Add("Все категории");
            Filt.Items.Add("Азбука");
            Filt.Items.Add("Азбука. Учебник для детей");
            Filt.Items.Add("Русский язык. Азбука 1 й класс");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.Items.Add("Русский язык. Учебник для детей");
            Filt.SelectedIndex = 0;
        }

        private void Update()
        {
            IEnumerable<ListsTextbooksApplication> liststextbooksapplications = CoreModel.init().ListsTextbooksApplications.Where(p => p.Name.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                liststextbooksapplications = liststextbooksapplications.Where(p => p.Name == Convert.ToString(Filt.SelectedItem));
            }

            DataGridLists_Textbooks_Application.ItemsSource = liststextbooksapplications.ToList();
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Lists_Textbooks_Application_Page(new ListsTextbooksApplication()));
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            ListsTextbooksApplication ListsTextbooksApplicationEdit = DataGridLists_Textbooks_Application.SelectedItem as ListsTextbooksApplication;
            NavigationService.Navigate(new Add_Lists_Textbooks_Application_Page(ListsTextbooksApplicationEdit));
        }

        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLists_Textbooks_Application.SelectedItems.Count > 1)
                return;
            ListsTextbooksApplication ListsTextbooksApplicationDel = DataGridLists_Textbooks_Application.SelectedItem as ListsTextbooksApplication;

            if (MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().ListsTextbooksApplications.Remove(ListsTextbooksApplicationDel);
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

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Будет разработано в ближайшем будущем");
        }
    }
}
