using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUIProject.Model;
using GUIProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GUIProject.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public double subject1;

        [ObservableProperty]
        public double subject2;

        [ObservableProperty]
        public double subject3;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent = null;


        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            LoadStudent();
            
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
        public void InsertStudent()
        {
            Student p = new Student()
            {
                Name = "",
                Age = 0,
                Subject_1 = 0,
                Subject_2 = 0,
                Subject_3 = 0,
                
            };

            selectedStudent = p;
            students.Add(p);

            using (var db = new UserDataContext())
            {
                db.Students.Add(p);
                db.SaveChanges();
            }
            LoadStudent();
        }

        [RelayCommand]
        public void UpdateStudent()
        {
            using (var db = new UserDataContext())
            {
                var existingStudent = db.Students.FirstOrDefault(p => p.Id == selectedStudent.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = selectedStudent.Name;
                    existingStudent.Age = selectedStudent.Age;
                    existingStudent.Subject_1 = selectedStudent.Subject_1;
                    existingStudent.Subject_2 = selectedStudent.Subject_2;
                    existingStudent.Subject_3 = selectedStudent.Subject_3;
                   
                    db.SaveChanges();
                }
            }
            LoadStudent();
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            using (var db = new UserDataContext())
            {
                var existingStudent = db.Students.FirstOrDefault(p => p.Id == selectedStudent.Id);
                if (existingStudent != null)
                {
                    db.Students.Remove(existingStudent);
                    db.SaveChanges();
                    students.Remove(selectedStudent);
                }
            }
            LoadStudent();
        }

        [RelayCommand]
        public void LoadStudent()
        {
            using (var db = new UserDataContext())
            {
                var list = db.Students.OrderBy(p => p.Id).ToList();
                students.Clear();
                foreach (var user in list)
                {
                    students.Add(user);
                }
            }
        }

        [RelayCommand]
        public void Logout()
        {
            LoginWindow loginWindow = new LoginWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
        }

    }
}
