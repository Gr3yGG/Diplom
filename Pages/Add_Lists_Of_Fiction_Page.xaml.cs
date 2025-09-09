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
    /// Interaction logic for Add_Lists_Of_Fiction_Page.xaml
    /// </summary>
    public partial class Add_Lists_Of_Fiction_Page : Page
    {
        ListsOfFiction listsOfFiction;
        public Add_Lists_Of_Fiction_Page(ListsOfFiction doc)
        {
            this.listsOfFiction = doc;
            DataContext = listsOfFiction;
            InitializeComponent();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (listsOfFiction.IdListsOfFiction != 0)
            {
                CoreModel.init().Entry(listsOfFiction).Reload();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (listsOfFiction.IdListsOfFiction == 0)
            {
                CoreModel.init().ListsOfFictions.Add(listsOfFiction);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}
