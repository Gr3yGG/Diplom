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
    /// Interaction logic for Add_SchoolBoy_Page.xaml
    /// </summary>
    public partial class Add_SchoolBoy_Page : Page
    {
        SchoolBoy schoolboy;
        public Add_SchoolBoy_Page(SchoolBoy doc)
        {
            this.schoolboy = doc;
            DataContext = schoolboy;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (schoolboy.IdSchoolBoy == 0)
            {
                CoreModel.init().SchoolBoys.Add(schoolboy);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (schoolboy.IdSchoolBoy != 0)
            {
                CoreModel.init().Entry(schoolboy).Reload();
            }
        }
    }
}
