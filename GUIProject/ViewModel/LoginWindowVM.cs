using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUIProject.View;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;
using System.Xml.Linq;


namespace GUIProject.ViewModel
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        public readonly UserDataContext dbContext;

        public LoginWindowVM()
        {

        }

        public LoginWindowVM(UserDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [RelayCommand]
        public void MinimizeWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        public void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        private void Login()
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Name == username && u.Pasword == password);

            if (user != null)
            {
                Window window;

                if (user.Role)
                {
                    window = new AdminWindow();
                }
                else
                {
                    window = new MainWindow();
                }

                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = window;
                window.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

