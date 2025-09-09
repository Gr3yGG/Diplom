using Diplom.Pages;
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
using System.Windows.Shapes;

namespace Diplom.Windows
{
    /// <summary>
    /// Interaction logic for Window_Menu.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        public Window_Menu()
        {
            InitializeComponent();
        }

        private void Show_User_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new User_Page());
        }

        private void Show_SchoolBoy_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new SchoolBoy_Page());
        }

        private void Show_Lists_Of_Fiction_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Lists_Of_Fiction_Page());
        }

        private void Show_Lists_Of_Textbook_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Lists_Of_Textbook_Page());
        }

        private void Show_Lists_Textbooks_Application_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Lists_Textbooks_Application_Page());
        }

        private void Show_Types_Of_Literature(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Types_Of_Literature());
        }

        private void MouseDown2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
