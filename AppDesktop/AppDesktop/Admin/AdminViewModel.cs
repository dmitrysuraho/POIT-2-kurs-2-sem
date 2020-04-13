using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppDesktop.Admin
{
    class AdminViewModel : INotifyPropertyChanged
    {
        private AdminWindow adminWindow;
        private MainWindow mainWindow;
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

        private Command addStudent;
        public Command AddStudent
        {
            get
            {
                return addStudent ??
                  (addStudent = new Command(obj =>
                  {
                      adminWindow.buttons.Visibility = Visibility.Collapsed;
                      adminWindow.reset.Visibility = Visibility.Visible;
                  }));
            }
        }
        private Command reset;
        public Command Reset
        {
            get
            {
                return reset ??
                  (reset = new Command(obj =>
                  {
                      adminWindow.reset.Visibility = Visibility.Collapsed;
                      adminWindow.buttons.Visibility = Visibility.Visible;
                  }));
            }
        }

        public AdminViewModel(AdminWindow win, MainWindow main)
        {
            adminWindow = win;
            mainWindow = main;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
