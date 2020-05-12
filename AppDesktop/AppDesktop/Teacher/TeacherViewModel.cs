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
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace AppDesktop.Teacher
{
    class TeacherViewModel : INotifyPropertyChanged
    {
        private string login;
        private TeacherWindow teacherWindow;
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
        private TeacherModel model;
        public TeacherModel Model
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
                      teacherWindow.Hide();
                      mainWindow.Show();
                  }));
            }
        }

        private Command studentList;
        public Command StudentList
        {
            get
            {
                return studentList ??
                    (studentList = new Command(obj =>
                    {
                        teacherWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                        teacherWindow.Frame.Visibility = Visibility.Visible;
                        ShowPage(new Pages.StudentsList.StudentsList(teacherWindow, login));
                    }));
            }
        }

        private Command addTest;
        public Command AddTest
        {
            get
            {
                return addTest ??
                  (addTest = new Command(obj =>
                  {
                      string str = $"select * from TESTS inner join TEACHER on TESTS.SUBJECT = TEACHER.SUBJECT where TEACHER.TEACHER = '{login}'";
                      SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                      SqlDataReader reader = sqlCommand.ExecuteReader();
                      int i = 0;
                      foreach (var x in reader)
                      {
                          i++;
                      }
                      reader.Close();
                      if (i == 0)
                      {
                          teacherWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                          teacherWindow.Frame.Visibility = Visibility.Visible;
                          ShowPage(new Pages.AddTestPage.AddChangeTest(teacherWindow, login));
                      }
                      else
                      {
                          MessageBoxResult result = MessageBox.Show("Тест по вашему предмету уже добавлен, хотите его удалить и добавить новый?" +
                              "\n(Если вы нажмете 'Да', то нынешний тест удалится без возможности восстановления)", "", MessageBoxButton.YesNo);
                          if(result == MessageBoxResult.Yes)
                          {
                              string str1 = $"select SUBJECT from TEACHER where TEACHER = '{login}'";
                              SqlCommand sqlCommand1 = new SqlCommand(str1, Connection.SqlConnection);
                              SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                              string subject = "";
                              foreach (var x in reader1)
                              {
                                  subject = reader1.GetString(0).Trim();
                              }
                              reader1.Close();
                              string str11 = $"delete from TESTS where SUBJECT = '{subject}'";
                              SqlCommand sqlCommand11 = new SqlCommand(str11, Connection.SqlConnection);
                              int num = sqlCommand11.ExecuteNonQuery();

                              teacherWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                              teacherWindow.Frame.Visibility = Visibility.Visible;
                              ShowPage(new Pages.AddTestPage.AddChangeTest(teacherWindow, login));
                          }
                      };
                  }));
            }
        }

        private Command addLiterature;
        public Command AddLiterature
        {
            get
            {
                return addLiterature ??
                  (addLiterature = new Command(obj =>
                  {
                      teacherWindow.GridAdminControl.Visibility = Visibility.Collapsed;
                      teacherWindow.Frame.Visibility = Visibility.Visible;
                      ShowPage(new Pages.AddLiteraturePage.AddLiterature(teacherWindow, login));
                  }));
            }
        }

        public TeacherViewModel(TeacherWindow win, MainWindow main, string login)
        {
            teacherWindow = win;
            mainWindow = main;
            FrameOpacity = 1;
            this.login = login;
            Model = new TeacherModel(login);
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
