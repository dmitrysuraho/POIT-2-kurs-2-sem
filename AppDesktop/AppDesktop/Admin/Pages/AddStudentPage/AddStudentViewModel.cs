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

namespace AppDesktop.Admin.Pages.AddStudentPage
{
    class AddStudentViewModel : INotifyPropertyChanged
    {
        private AdminWindow adminWindow;

        private AddStudentModel model;
        public AddStudentModel Model
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

        public AddStudentViewModel(AdminWindow admin)
        {
            adminWindow = admin;
            PageOpacity = 1;
            Model = new AddStudentModel();
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
            adminWindow.GridAdminControl.Visibility = Visibility.Visible;
            adminWindow.Frame.Visibility = Visibility.Collapsed;
        }
    }
}
