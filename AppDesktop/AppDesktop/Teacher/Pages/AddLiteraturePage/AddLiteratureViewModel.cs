using Microsoft.Win32;
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

namespace AppDesktop.Teacher.Pages.AddLiteraturePage
{
    class AddLiteratureViewModel : INotifyPropertyChanged
    {
        private TeacherWindow teacherWindow;

        private AddLiteratureModel model;
        public AddLiteratureModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private double pageOpacity;
        public double PageOpacity
        {
            get { return pageOpacity; }
            set
            {
                pageOpacity = value;
                OnPropertyChanged("PageOpacity");
            }
        }

        private Command addPicture;
        public Command AddPicture
        {
            get
            {
                return addPicture ??
                  (addPicture = new Command(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Image files (*.jpg)|*.jpg|(*.png)|*.png";
                      if (openFileDialog.ShowDialog() == true)
                      {
                          model.File = openFileDialog.FileName;
                          model.FileName = openFileDialog.SafeFileName;
                      }
                  }));
            }
        }

        private Command add;
        public Command Add
        {
            get
            {
                return add ??
                  (add = new Command(obj =>
                  {
                      if (model.Add())
                      {
                          ShowPage();
                      }
                  }));
            }
        }

        private Command cancel;
        public Command Cancel
        {
            get
            {
                return cancel ??
                  (cancel = new Command(obj =>
                  {
                      ShowPage();
                  }));
            }
        }

        public AddLiteratureViewModel(TeacherWindow teacher, string login)
        {
            teacherWindow = teacher;
            PageOpacity = 1;
            Model = new AddLiteratureModel(login);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async void ShowPage()
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(50);
                }
            });
            teacherWindow.GridAdminControl.Visibility = Visibility.Visible;
            teacherWindow.Frame.Visibility = Visibility.Collapsed;
        }
    }
}
