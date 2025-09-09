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
    /// Interaction logic for Add_Types_Of_Literature.xaml
    /// </summary>
    public partial class Add_Types_Of_Literature : Page
    {
        TypesOfLiterature typesOfLiterature;
        public Add_Types_Of_Literature(TypesOfLiterature doc)
        {
            this.typesOfLiterature = doc;
            DataContext = typesOfLiterature;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (typesOfLiterature.IdTypesOfLiterature == 0)
            {
                CoreModel.init().TypesOfLiteratures.Add(typesOfLiterature);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void Doc_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (typesOfLiterature.IdTypesOfLiterature != 0)
            {
                CoreModel.init().Entry(typesOfLiterature).Reload();
            }
        }
    }
}
