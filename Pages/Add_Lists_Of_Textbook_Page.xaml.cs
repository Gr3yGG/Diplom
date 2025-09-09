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
    /// Interaction logic for Add_Lists_Of_Textbook_Page.xaml
    /// </summary>
    public partial class Add_Lists_Of_Textbook_Page : Page
    {
        ListsOfTextbook listsOfTextbook;
        public Add_Lists_Of_Textbook_Page(ListsOfTextbook doc)
        {
            this.listsOfTextbook = doc;
            DataContext = listsOfTextbook;
            InitializeComponent();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (listsOfTextbook.IdListsOfTextbook != 0)
            {
                CoreModel.init().Entry(listsOfTextbook).Reload();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (listsOfTextbook.IdListsOfTextbook == 0)
            {
                CoreModel.init().ListsOfTextbooks.Add(listsOfTextbook);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}
