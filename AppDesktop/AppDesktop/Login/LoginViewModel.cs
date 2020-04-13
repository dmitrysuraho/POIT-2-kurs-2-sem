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
        private LoginModel model;
        private Users users;

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
                          Check(obj, "select * from ADMIN");
                      }
                      else if (users == Users.Teacher)
                      {
                          Check(obj, "select * from TEACHER");
                      }
                      else if (users == Users.Student)
                      {
                          Check(obj, "select * from STUDENT");
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

        private string GetHash(string str)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str); 
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }

        private void Check(object obj, string str)
        {
            var passwordBox = obj as PasswordBox;
            string passwordEnter = GetHash(passwordBox.Password);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = str;
            sqlCommand.Connection = Connection.SqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string passwordData = "";
            bool flag = false;
            string objRead;
            foreach (var i in reader)
            {
                if (str.Contains("STUDENT")) objRead = reader.GetInt32(0).ToString().Replace(" ", "");
                else objRead = reader.GetString(0).Replace(" ", "");
                if (objRead == model.Login)
                {
                    passwordData = reader.GetString(1).Replace(" ", "");
                    flag = true;
                    break;
                }
            }
            reader.Close();
            if (flag)
            {
                if (passwordData == passwordEnter)
                {
                    MessageBox.Show("Вход успешен");
                    mainWindow.Hide();
                    if (str.Contains("ADMIN"))
                    {
                        AdminWindow admin = new AdminWindow(mainWindow);
                        admin.Show();
                    }
                    else if (str.Contains("TEACHER"))
                    {
                        TeacherWindow teacher = new TeacherWindow();
                        teacher.Show();
                    }
                    else
                    {
                        StudentWindow student = new StudentWindow();
                        student.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
