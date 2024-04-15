using GUIProject.Model;
using GUIProject.View;
using GUIProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace GUIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private List<Student> DatabaseStdents;

        public MainWindow()
        {
            DataContext = new MainWindowVM();
            InitializeComponent();
        }

        private void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /* MenuItem_Click
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
        */

        //private void lblBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    LoginWindow loginWindow = new LoginWindow();
        //    Application.Current.MainWindow.Close();
        //    Application.Current.MainWindow = loginWindow;
        //    loginWindow.Show();
        //}

        private void drag_Me1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
