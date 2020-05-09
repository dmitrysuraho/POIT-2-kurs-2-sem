using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppDesktop.Student
{
    class StudentViewModel : INotifyPropertyChanged
    {
        private string login;
        private StudentWindow studentWindow;
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
        private StudentModel model;
        public StudentModel Model
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
                      studentWindow.Hide();
                      mainWindow.Show();
                  }));
            }
        }

        private Command test;
        public Command Test
        {
            get
            {
                return test ??
                  (test = new Command(obj =>
                  {
                      studentWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      studentWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.TestPage.Test(studentWindow, login));
                  }));
            }
        }

        private Command profile;
        public Command Profile
        {
            get
            {
                return profile ??
                  (profile = new Command(obj =>
                  {
                      studentWindow.Profile.IsEnabled = false;
                      studentWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      studentWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.ProfilePage.Profile(studentWindow, login));
                  }));
            }
        }

        private Command news;
        public Command News
        {
            get
            {
                return news ??
                  (news = new Command(obj =>
                  {
                      studentWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      studentWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.NewsPage.News(studentWindow));
                  }));
            }
        }

        private Command progress;
        public Command Progress
        {
            get
            {
                return progress ??
                  (progress = new Command(obj =>
                  {
                      studentWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      studentWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.ProgressPage.Progress(studentWindow, login));
                  }));
            }
        }

        private Command subjects;
        public Command Subjects
        {
            get
            {
                return subjects ??
                  (subjects = new Command(obj =>
                  {
                      studentWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      studentWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.SubjectsPage.Subjects(studentWindow, login));
                  }));
            }
        }

        public StudentViewModel(StudentWindow win, MainWindow main, string login)
        {
            studentWindow = win;
            mainWindow = main;
            FrameOpacity = 1;
            this.login = login;
            Model = new StudentModel(login);
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
