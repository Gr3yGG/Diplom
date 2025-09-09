using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for SchoolBoy_Page.xaml
    /// </summary>
    public partial class SchoolBoy_Page : Page
    {
        public SchoolBoy_Page()
        {
            InitializeComponent();
            Update();

            Filt.Items.Add("Все категории");
            Filt.Items.Add("Петров");
            Filt.Items.Add("Сергеев");
            Filt.Items.Add("Павлов");
            Filt.Items.Add("Михайлов");
            Filt.Items.Add("Александров");
            Filt.Items.Add("Иванов");
            Filt.SelectedIndex = 0;
        }
        private void Update()
        {
            IEnumerable<SchoolBoy> schoolboys = CoreModel.init().SchoolBoys.Where(p => p.Surname.Contains(Search.Text));

            if (Filt.SelectedIndex > 0)
            {
                schoolboys = schoolboys.Where(p => p.Surname == Convert.ToString(Filt.SelectedItem));
            }

            DataGridSchoolBoy.ItemsSource = schoolboys.ToList();
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
            NavigationService.Navigate(new Add_SchoolBoy_Page(new SchoolBoy()));
        }

        private void Del_Show_Click()
        {

        }

        private void Del_Show_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSchoolBoy.SelectedItems.Count > 1)
                return;
            SchoolBoy SchoolBoyDel = DataGridSchoolBoy.SelectedItem as SchoolBoy;

            if (MessageBox.Show("Удалить?", "Серьёзно удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().SchoolBoys.Remove(SchoolBoyDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            SchoolBoy SchoolBoyEdit = DataGridSchoolBoy.SelectedItem as SchoolBoy;
            NavigationService.Navigate(new Add_SchoolBoy_Page(SchoolBoyEdit));
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
