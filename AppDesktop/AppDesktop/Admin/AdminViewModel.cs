using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppDesktop.Admin
{
    class AdminViewModel : INotifyPropertyChanged
    {
        private AdminWindow adminWindow;
        private MainWindow mainWindow;
        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        private AdminModel model;
        public AdminModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set
            {
                frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }
        private Command exit;
        public Command Exit
        {
            get
            {
                return exit ??
                  (exit = new Command(obj =>
                  {
                      adminWindow.Hide();
                      mainWindow.Show();
                  }));
            }
        }

        private Command addStudents;
        public Command AddStudents
        {
            get
            {
                return addStudents ??
                  (addStudents = new Command(obj =>
                  {
                      adminWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      adminWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.AddStudentPage.AddStudent(adminWindow));
                  }));
            }
        }

        private Command addTeacher;
        public Command AddTeacher
        {
            get
            {
                return addTeacher ??
                  (addTeacher = new Command(obj =>
                  {
                      adminWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      adminWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.AddTeacherPage.AddTeacher(adminWindow));
                  }));
            }
        }

        private Command addNews;
        public Command AddNews
        {
            get
            {
                return addNews ??
                  (addNews = new Command(obj =>
                  {
                      adminWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      adminWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.AddNewsPage.AddNews(adminWindow));
                  }));
            }
        }

        public AdminViewModel(AdminWindow win, MainWindow main)
        {
            adminWindow = win;
            mainWindow = main;
            FrameOpacity = 1;
            Model = new AdminModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async void ShowPage(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
            
        }
    }
}
