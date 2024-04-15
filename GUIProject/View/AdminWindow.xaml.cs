using GUIProject.Model;
using GUIProject.ViewModel;
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
using System.Windows.Threading;

namespace GUIProject.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private List<User> DatabaseUsers;

        DispatcherTimer timer;
        double panelWidth;
        bool hidden;

        public AdminWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
            panelWidth = sidePanel.Width;
        }

        private void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void drag_Me2(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {

            if (hidden)
            {
                sidePanel.Width += 15;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 15;
                if (sidePanel.Width <= 60)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }


    }
}
