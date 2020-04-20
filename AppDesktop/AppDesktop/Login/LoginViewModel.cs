using Students.RelayCommand;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.SqlClient;
using Students.DataBaseConnection;
using AppDesktop.Login;
using System.Windows.Controls;
using AppDesktop;

namespace Students.MainWindow
{
    enum Users { Admin = 1, Teacher, Student };
    class LoginViewModel : INotifyPropertyChanged
    {
        private AppDesktop.MainWindow mainWindow;
        private Users users;

        private LoginModel model;
        public LoginModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private Command logIn;
        public Command LogIn
        {
            get
            {
                return logIn ??
                  (logIn = new Command(obj =>
                  {
                      if (users == Users.Admin)
                      {
                          if (model.Check(obj, "select * from ADMIN"))
                          {
                              mainWindow.Hide();
                              AdminWindow admin = new AdminWindow(mainWindow);
                              admin.Show();
                          }
                          else MessageBox.Show("Неверный логин или пароль");
                      }
                      else if (users == Users.Teacher)
                      {
                          if (model.Check(obj, "select * from TEACHER"))
                          {
                              mainWindow.Hide();
                              TeacherWindow teacher = new TeacherWindow();
                              teacher.Show();
                          }
                          else MessageBox.Show("Неверный логин или пароль");
                      }
                      else if (users == Users.Student)
                      {
                          if (model.Check(obj, "select * from STUDENT"))
                          {
                              mainWindow.Hide();
                              StudentWindow student = new StudentWindow();
                              student.Show();
                          }
                          else MessageBox.Show("Неверный логин или пароль");
                      }
                      else
                      {
                          MessageBox.Show("Выберите роль");
                      }
                  }));
            }
        }

        private Command adminCheck;
        public Command AdminCheck
        {
            get
            {
                return adminCheck ??
                  (adminCheck = new Command(obj =>
                  {
                      users = Users.Admin;
                  }));
            }
        }

        private Command teacherCheck;
        public Command TeacherCheck
        {
            get
            {
                return teacherCheck ??
                  (teacherCheck = new Command(obj =>
                  {
                      users = Users.Teacher;
                  }));
            }
        }

        private Command studentCheck;
        public Command StudentCheck
        {
            get
            {
                return studentCheck ??
                  (studentCheck = new Command(obj =>
                  {
                      users = Users.Student;
                  }));
            }
        }

        public LoginViewModel(AppDesktop.MainWindow win)
        {
            Model = new LoginModel();
            mainWindow = win;
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
