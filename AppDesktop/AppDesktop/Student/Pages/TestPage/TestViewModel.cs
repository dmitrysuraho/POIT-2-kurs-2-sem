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

namespace AppDesktop.Student.Pages.TestPage
{
    class TestViewModel : INotifyPropertyChanged
    {
        private StudentWindow studentWindow;

        public ObservableCollection<TestModel> Subjects { get; set; } = new ObservableCollection<TestModel>();
        public ObservableCollection<TestModel> Test { get; set; } = new ObservableCollection<TestModel>();


        private TestModel selectedSubject;
        public TestModel SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }

        private TestModel selectedTest;
        public TestModel SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
                OnPropertyChanged("SelectedTest");
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

        private Command start;
        public Command Start
        {
            get
            {
                return start ??
                  (start = new Command(obj =>
                  {
                      if (SelectedSubject != null)
                      {
                          Test.Clear();
                          string subject = SelectedSubject.SubjectName;
                          string subj = $"select SUBJECT, QUESTION, ANSWER from TESTS where SUBJECT = '{subject}'";
                          SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                          SqlDataReader reader = sqlCom.ExecuteReader();
                          foreach(var x in reader)
                          {
                              Test.Add(new TestModel { Question = reader.GetString(1),
                                                       Answer = reader.GetString(2) });
                          }
                          reader.Close();
                      }
                      else
                      {
                          MessageBox.Show("Выберите предмет");
                      }
                  }));
            }
        }

        public TestViewModel(StudentWindow student, string login)
        {
            studentWindow = student;
            PageOpacity = 1;

            string subj = $"select SUBJECT from SUBJECT inner join STUDENT on SUBJECT.COURSE = STUDENT.COURSE where RECORD = {login}";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            foreach (var i in reader)
            {
                Subjects.Add(new TestModel { SubjectName = reader.GetString(0) });
            }
            reader.Close();
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
