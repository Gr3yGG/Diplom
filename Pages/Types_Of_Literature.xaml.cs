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
    /// Interaction logic for Types_Of_Literature.xaml
    /// </summary>
    public partial class Types_Of_Literature : Page
    {
        public Types_Of_Literature()
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
            IEnumerable<TypesOfLiterature> typesofliteratures = CoreModel.init().TypesOfLiteratures.Where(p => p.Author.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                typesofliteratures = typesofliteratures.Where(p => p.Author == Convert.ToString(Filt.SelectedItem));
            }

            DataGridTypes_Of_Literature.ItemsSource = typesofliteratures.ToList();
        }

        private void Doc_Vis_Change()
        {

        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Types_Of_Literature(new TypesOfLiterature()));
        }

        private void Del_Show_Click()
        {

        }

        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTypes_Of_Literature.SelectedItems.Count > 1)
                return;
            TypesOfLiterature TypesOfLiteratureDel = DataGridTypes_Of_Literature.SelectedItem as TypesOfLiterature;

            if (MessageBox.Show("Удалить?", "Серьёзно удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().TypesOfLiteratures.Remove(TypesOfLiteratureDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            TypesOfLiterature TypesLiteratureEdit = DataGridTypes_Of_Literature.SelectedItem as TypesOfLiterature;
            NavigationService.Navigate(new Add_Types_Of_Literature(TypesLiteratureEdit));
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
