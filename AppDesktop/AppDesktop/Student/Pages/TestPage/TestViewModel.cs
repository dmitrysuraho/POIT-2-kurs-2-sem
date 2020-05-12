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
        private Test test;
        private bool timer = false;

        private string login;

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

        private TestModel model;
        public TestModel Model
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
                          string progr = $"select * from PROGRESS";
                          SqlCommand sqlCom1 = new SqlCommand(progr, Connection.SqlConnection);
                          SqlDataReader reader1 = sqlCom1.ExecuteReader();
                          bool note = false;
                          foreach (var x in reader1)
                          {
                              if (reader1.GetString(0) == selectedSubject.SubjectName &&
                                    reader1.GetInt32(1).ToString() == login)
                              {
                                  note = true;
                              }
                          }
                          reader1.Close();

                          if (!note)
                          {
                              Test.Clear();
                              string subject = SelectedSubject.SubjectName;
                              string subj = $"select SUBJECT, QUESTION, ANSWER, NOANSWER1, NOANSWER2 from TESTS where SUBJECT = '{subject}'";
                              SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                              SqlDataReader reader = sqlCom.ExecuteReader();
                              foreach (var x in reader)
                              {
                                  Test.Add(new TestModel
                                  {
                                      Question = reader.GetString(1),
                                      Answer = reader.GetString(2),
                                      NoAnswer1 = reader.GetString(3),
                                      NoAnswer2 = reader.GetString(4)
                                  });
                              }
                              reader.Close();
                              if (Test.Count != 0)
                              {
                                  studentWindow.Profile.IsEnabled = false;
                                  studentWindow.Exit.IsEnabled = false;
                                  test.LeftColumn.IsEnabled = false;
                                  test.RightColumn.Visibility = Visibility.Visible;
                                  Timer();
                              }
                              else
                              {
                                  MessageBox.Show("Данный тест еще не добавили");
                              }
                          }
                          else
                          {
                              MessageBox.Show("Вы уже проходили этот тест");
                          }
                      }
                      else
                      {
                          MessageBox.Show("Выберите предмет");
                      }
                  }));
            }
        }

        private Command endTest;
        public Command EndTest
        {
            get
            {
                return endTest ??
                  (endTest = new Command(obj =>
                  {
                      timer = true;
                      MessageBox.Show($"Ваш результат: {TestModel.progress}");
                      studentWindow.Profile.IsEnabled = true;
                      studentWindow.Exit.IsEnabled = true;
                      test.LeftColumn.IsEnabled = true;
                      test.RightColumn.Visibility = Visibility.Hidden;
                      TestModel.progress = 0;
                  }));
            }
        }

        public TestViewModel(Test test, StudentWindow student, string login)
        {
            this.login = login;
            this.test = test;
            studentWindow = student;
            PageOpacity = 1;
            Model = new TestModel();
            model.Timer = "Время: 1:00";

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

        private async void Timer()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i >= 0; i--)
                {
                    for (int j = 59; j >= 0; j--)
                    {
                        if (timer) 
                        {
                            model.Timer = "Время: 1:00";
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            if (j < 10) model.Timer = $"Время: {i}:0{j}";
                            else model.Timer = $"Время: {i}:{j}";
                        }
                    }
                }
            });
            if (!timer)
            {
                MessageBox.Show("Время вышло");
                MessageBox.Show($"Ваш результат: {TestModel.progress}");
                studentWindow.Profile.IsEnabled = true;
                studentWindow.Exit.IsEnabled = true;
                test.RightColumn.Visibility = Visibility.Hidden;
                test.LeftColumn.IsEnabled = true;
            }
            if (TestModel.progress == 0)
                TestModel.progress++;
            string subj = $"insert into PROGRESS(SUBJECT, IDSTUDENT, NOTE) values('{selectedSubject.SubjectName}', {login}, {TestModel.progress})";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            int reader = sqlCom.ExecuteNonQuery();
            timer = false;
            TestModel.progress = 0;
        }
    }
}
