using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace AppDesktop.Student.Pages.ProgressPage
{
    class ProgressViewModel : INotifyPropertyChanged
    {
        private StudentWindow studentWindow;
        private string login;

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

        public ObservableCollection<ProgressModel> Notes { get; set; } = new ObservableCollection<ProgressModel>();

        public ProgressViewModel(StudentWindow student, string login)
        {
            studentWindow = student;
            this.login = login;
            PageOpacity = 1;

            string subj = $"select SUBJECT from SUBJECT inner join STUDENT on SUBJECT.COURSE = STUDENT.COURSE where STUDENT.RECORD = {login}";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            List<string> subjects = new List<string>();
            foreach(var x in reader)
            {
                subjects.Add(reader.GetString(0).Trim());
            }
            reader.Close();
            string progress = $"select PROGRESS.SUBJECT, PROGRESS.NOTE from PROGRESS inner join STUDENT on PROGRESS.IDSTUDENT = STUDENT.RECORD where STUDENT.RECORD = {login}";
            SqlCommand sqlCom2 = new SqlCommand(progress, Connection.SqlConnection);
            SqlDataReader reader2 = sqlCom2.ExecuteReader();
            Dictionary<string, int> progr = new Dictionary<string, int>();
            foreach(var x in reader2)
            {
                progr.Add(reader2.GetString(0).Trim(), reader2.GetInt32(1));
            }
            reader2.Close();
            foreach(var x in subjects)
            {
                if(progr.ContainsKey(x))
                {
                    Notes.Add(new ProgressModel
                    {
                        Subject = x,
                        Note = progr[x]
                    });
                }
                else
                {
                    Notes.Add(new ProgressModel
                    {
                        Subject = x + " - нет результата"
                    });
                }
            }
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
            studentWindow.GridAdminControl.Visibility = Visibility.Visible;
            studentWindow.Frame.Visibility = Visibility.Collapsed;
        }
    }
}
