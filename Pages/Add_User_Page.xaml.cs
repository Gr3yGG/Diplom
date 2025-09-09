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
    /// Interaction logic for Add_User_Page.xaml
    /// </summary>
    public partial class Add_User_Page : Page
    {
        User user;
        public Add_User_Page(User doc)
        {
            this.user = doc;
            DataContext = user;

            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (user.IdUser == 0)
            {
                CoreModel.init().Users.Add(user);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (user.IdUser != 0)
            {
                CoreModel.init().Entry(user).Reload();
            }
        }
    }
}
