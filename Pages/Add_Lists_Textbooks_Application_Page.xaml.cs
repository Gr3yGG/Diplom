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
    /// Interaction logic for Add_Lists_Textbooks_Application_Page.xaml
    /// </summary>
    public partial class Add_Lists_Textbooks_Application_Page : Page
    {
        ListsTextbooksApplication listsTextbooksApplication;
        public Add_Lists_Textbooks_Application_Page(ListsTextbooksApplication doc)
        {
            this.listsTextbooksApplication = doc;
            DataContext = listsTextbooksApplication;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (listsTextbooksApplication.IdListsTextbooksApplication == 0)
            {
                CoreModel.init().ListsTextbooksApplications.Add(listsTextbooksApplication);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (listsTextbooksApplication.IdListsTextbooksApplication != 0)
            {
                CoreModel.init().Entry(listsTextbooksApplication).Reload();
            }
        }
    }
}
